using MediatR;
using registerAPI.Commands.RentedMotorcycle.DeleteRental;
using registerAPI.Services;
using registerAPI.Services.Interfaces;

namespace registerAPI.Commands.RentedMotorcycle.DeleteLease
{
    public class DeleteRentalCommandHandler : IRequestHandler<DeleteRentalCommand, string>
    {
        private readonly IRentedService _rentedService;
        private readonly ILogger<DeleteRentalCommandHandler> _logger;
        public DeleteRentalCommandHandler(IRentedService rentedService, ILogger<DeleteRentalCommandHandler> logger)
        {
            _rentedService = rentedService;
            _logger = logger;

        }

        public async Task<string> Handle(DeleteRentalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Start Delete Lease");

                await _rentedService.RemoveAsync(request.BikeLicense);

                _logger.LogInformation("Ended Delete Lease");

                return "Deletado com sucesso!";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Delete Lease - Error {ex.Message}");
                throw new Exception("Erro ao deletar");
            }
        }
    }
}
