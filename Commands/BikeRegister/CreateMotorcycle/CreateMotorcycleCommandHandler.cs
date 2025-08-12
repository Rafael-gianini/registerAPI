using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RabbitMQ.Client;
using registerAPI.Entity;
using registerAPI.Services;
using registerAPI.Services.Interfaces;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;

namespace registerAPI.Commands.City.CreateOrUpdateMotocycle
{
    public class CreateMotorcycleCommandHandler : IRequestHandler<CreateMotorcycleCommand, string>
    {
        private readonly IMotorcycleService _bikeService;
        private readonly ILogger<CreateMotorcycleCommandHandler> _logger;
        public CreateMotorcycleCommandHandler(IMotorcycleService bikeService, ILogger<CreateMotorcycleCommandHandler> logger)
        {
            _bikeService = bikeService;
            _logger = logger;
        }

        public async Task<string> Handle(CreateMotorcycleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Start Create Motorcycle");

                var bikeLicense = !string.IsNullOrEmpty(request.Bike.BikeLicensePlate) ? request.Bike.BikeLicensePlate?.ToUpper() : "";
                request.Bike.BikeLicensePlate = bikeLicense;

                var existsBike = await _bikeService.GetByLicense(bikeLicense);

                if (existsBike is not null)
                    throw new ArgumentException("Motocicleta já cadastrada");

                _logger.LogInformation("Ended Create Motorcycle");

                if (request.Bike.YearBike.Equals(2024))
                {
                    await MotorcycleRegisterEventPublish(bikeLicense, request.Bike.YearBike);
                    var message = await MotorcycleRegisterEventConsumer();

                   if (!string.IsNullOrEmpty(message)) await _bikeService.CreateAsync(request.Bike);
                }

                return "Criado com sucesso!";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Create Motorcycle - Error: {ex.Message}");

                if (ex is ArgumentException)
                    throw new ArgumentException(ex.Message);

                throw new ArgumentException("Erro ao cadastrar");
            }
        }

        public Task<Unit> MotorcycleRegisterEventPublish(string? bikeLicense, int yearBike)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ConfirmSelect();
                channel.QueueDeclare(queue: "register",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                _logger.LogInformation($"Cadastro concluído: Placa {bikeLicense} - Ano {yearBike}");

                // Envia a mensagem
                var message = $"Novo cadastro: Placa: {bikeLicense} - Ano {yearBike}";
                var stringfiedMessage = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(stringfiedMessage);
                channel.BasicPublish(exchange: "",
                                     routingKey: "register",
                                     basicProperties: null,
                                     body: body);

                _logger.LogTrace($"Mensagem enviada para o RabbitMQ: {message}");
            }
                      
            return Unit.Task;
        }

        public Task<string> MotorcycleRegisterEventConsumer()
        {
            var message = "";
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ConfirmSelect();
                channel.QueueDeclare(queue: "register",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                };
                channel.BasicConsume(queue: "register",
                                     autoAck: true,
                                     consumer: consumer);

                _logger.LogTrace($"Mensagem consumida da fila: {message}");
            }

            return Task.FromResult(message);
        }
    }
}
