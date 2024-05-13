﻿using MediatR;
using registerAPI.Services;
using registerAPI.Services.Interfaces;

namespace registerAPI.Commands.RentedMotorcycle.DeleteLease
{
    public class DeleteRentalCommandHandler : IRequestHandler<DeleteLeaseCommand>
    {
        private readonly IRentedService _rentedService;
        private readonly ILogger<DeleteRentalCommandHandler> _logger;
        public DeleteRentalCommandHandler(IRentedService rentedService, ILogger<DeleteRentalCommandHandler> logger)
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
