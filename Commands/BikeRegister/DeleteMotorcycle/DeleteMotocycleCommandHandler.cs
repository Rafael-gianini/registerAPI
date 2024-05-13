using MediatR;
using registerAPI.Services;
using registerAPI.Services.Interfaces;
using System;

namespace registerAPI.Commands.City.DeleteMotorcycle
{
    public class DeleteMotocycleCommandHandler : IRequestHandler<DeleteMotocycleCommand>
    {
        private readonly IBikeService _cityService;
        private readonly ILogger<DeleteMotocycleCommandHandler> _logger;
        public DeleteMotocycleCommandHandler(IBikeService cityService, ILogger<DeleteMotocycleCommandHandler> logger)
        {
            _cityService = cityService;
            _logger = logger;

        }

        public async Task<Unit> Handle(DeleteMotocycleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Start Delete Motorcycle");

                await _cityService.RemoveAsync(request.AliasKey);

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
