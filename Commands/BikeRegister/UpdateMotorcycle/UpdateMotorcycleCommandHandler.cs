using AutoMapper;
using MediatR;
using registerAPI.Entity;
using registerAPI.Services.Interfaces;

namespace registerAPI.Commands.BikeRegister.UpdateMotorcycle
{
    public class UpdateMotorcycleCommandHandler : IRequestHandler<UpdateMotorcycleCommand, string>
    {
        private readonly IMotorcycleService _motorcycleService;
        private readonly ILogger<UpdateMotorcycleCommandHandler> _logger;
        
        public UpdateMotorcycleCommandHandler(IMotorcycleService motorcycleService, ILogger<UpdateMotorcycleCommandHandler> logger)
        {
            _motorcycleService = motorcycleService;
            _logger = logger;
          
        }

        public async Task<string> Handle(UpdateMotorcycleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Start Update Motorcycle");

                var updateMoto = await _motorcycleService.GetByLicense(request.Moto.WrongBikeLicensePlate);
              
                if (updateMoto is not null)
                {
                    updateMoto.BikeLicensePlate = request.Moto.UpdategBikeLicensePlate;
                    await _motorcycleService.UpdateAsync(request.Moto.WrongBikeLicensePlate, updateMoto);

                    _logger.LogInformation($"Ended Update Motorcycle");
                }
                else
                    throw new ArgumentException("Motocicleta não encontrada! Verifique se digitou a placa corretamente.");

                return "Atualizado com sucesso!";
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)

                    throw new ArgumentException(ex.Message);

                throw new Exception("Erro ao atualizar");
            }
            
        }
    }
}
