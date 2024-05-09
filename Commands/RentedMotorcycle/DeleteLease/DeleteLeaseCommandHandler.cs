using MediatR;
using registerAPI.Services;

namespace registerAPI.Commands.RentedMotorcycle.DeleteLease
{
    public class DeleteLeaseCommandHandler : IRequestHandler<DeleteLeaseCommand>
    {
        private readonly RentedService _rentedService;
        private readonly ILogger<DeleteLeaseCommandHandler> _logger;
        public DeleteLeaseCommandHandler(RentedService rentedService, ILogger<DeleteLeaseCommandHandler> logger)
        {
            _rentedService = rentedService;
            _logger = logger;

        }

        public async Task<Unit> Handle(DeleteLeaseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Start Delete Lease");

                await _rentedService.RemoveAsync(request.BikeLicense);

                _logger.LogInformation("Ended Delete Lease");

                return Unit.Value;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Delete Lease - Error {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
