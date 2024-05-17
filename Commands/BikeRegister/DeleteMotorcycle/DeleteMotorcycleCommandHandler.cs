using MediatR;
using registerAPI.Services;
using registerAPI.Services.Interfaces;
using System;

namespace registerAPI.Commands.City.DeleteMotorcycle
{
    public class DeleteMotorcycleCommandHandler : IRequestHandler<DeleteMotorcycleCommand>
    {
        private readonly IMotorcycleService _cityService;
        private readonly IRentedService _rentedService;
        private readonly ILogger<DeleteMotorcycleCommandHandler> _logger;
        public DeleteMotorcycleCommandHandler(IMotorcycleService cityService, IRentedService rentedService, ILogger<DeleteMotorcycleCommandHandler> logger)
        {
            _cityService = cityService;
            _rentedService = rentedService;
            _logger = logger;

        }

        public async Task<Unit> Handle(DeleteMotorcycleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Start Delete Motorcycle");

                var existsRental = await _rentedService.GetByLicense(request.MotorcycleLicense.ToUpper());

                if (existsRental is null)
                    await _cityService.RemoveAsync(request.MotorcycleLicense.ToUpper());
                else
                    throw new ArgumentException("Motocicleta não pode ser deletada. Existe uma locação em aberto");

                _logger.LogInformation("Ended Delete Motorcycle");

            }
            catch (Exception ex)
            {
                _logger.LogError($"Delete Motorcycle - Error {ex.Message}");
                throw new Exception(ex.Message);
            }
            return Unit.Value;
        }
    }
}
