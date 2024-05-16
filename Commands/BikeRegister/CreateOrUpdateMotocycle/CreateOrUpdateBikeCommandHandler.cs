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

namespace registerAPI.Commands.City.CreateOrUpdateMotocycle
{
    public class CreateOrUpdateBikeCommandHandler : IRequestHandler<CreateOrUpdateBikeCommand>
    {
        private readonly IBikeService _bikeService;
        private readonly ILogger<CreateOrUpdateBikeCommandHandler> _logger;
        public CreateOrUpdateBikeCommandHandler(IBikeService bikeService, ILogger<CreateOrUpdateBikeCommandHandler> logger)
        {
            _bikeService = bikeService;
            _logger = logger;
        }

        public async Task<Unit> Handle(CreateOrUpdateBikeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Start Create Motorcycle");

                request.Bike.Id = Guid.NewGuid();
                var bikeLicense = !string.IsNullOrEmpty(request.Bike.BikeLicensePlate) ? request.Bike.BikeLicensePlate?.ToUpper() : "";
                request.Bike.BikeLicensePlate = bikeLicense;

                var existsBike = await _bikeService.GetByLicense(bikeLicense);

                if (existsBike is not null)
                    throw new ArgumentException("Motocicleta já cadastrada");

                await _bikeService.CreateAsync(request.Bike);

                _logger.LogInformation("Ended Create Motorcycle");

                if (request.Bike.YearBike.Equals(2024))
                    await MotorcycleRegisterEvent(bikeLicense, request.Bike.YearBike);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Create Motorcycle - Error: {ex.Message}");
                throw new ArgumentException("Erro ao cadastrar");
            }

        }

        public Task<Unit> MotorcycleRegisterEvent(string? bikeLicense, int yearBike)
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

                _logger.LogTrace("Mensagem enviada para o RabbitMQ.");
            }
                      
            return Unit.Task;
        }
    }
}
