using AutoMapper;
using MediatR;
using registerAPI.Entity;
using registerAPI.Services.Interfaces;

namespace registerAPI.Commands.BikeRegister.UpdateMotorcycle
{
    public class UpdateMotorcycleCommandHandler : IRequestHandler<UpdateMotorcycleCommand>
    {
        private readonly IMotorcycleService _motorcycleService;
        private readonly ILogger<UpdateMotorcycleCommandHandler> _logger;
        
        public UpdateMotorcycleCommandHandler(IMotorcycleService motorcycleService, ILogger<UpdateMotorcycleCommandHandler> logger)
        {
            _motorcycleService = motorcycleService;
            _logger = logger;
          
        }

        public async Task<Unit> Handle(UpdateMotorcycleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Start Update Motorcycle");

                var updateMoto = await _motorcycleService.GetByLicense(request.Moto.WrongBikeLicensePlate);
              
                if (updateMoto is null)
                {
                    updateMoto.BikeLicensePlate = request.Moto.UpdategBikeLicensePlate;
                    await _motorcycleService.UpdateAsync(request.Moto.WrongBikeLicensePlate, updateMoto);
                }
                else
                    throw new ArgumentException("Motocicleta já cadastrada");

                return Unit.Value;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
