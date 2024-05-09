

using MediatR;
using registerAPI.Services;

namespace registerAPI.Commands.Person.DeletePerson
{
    public class DeleteDeliveryPersonCommandHandler : IRequestHandler<DeleteDeliveryPersonCommand>
    {
        private readonly DeliveryPersonService _peopleService;
        private readonly ILogger<DeleteDeliveryPersonCommandHandler> _logger; 

        public DeleteDeliveryPersonCommandHandler(DeliveryPersonService peopleService, ILogger<DeleteDeliveryPersonCommandHandler> logger)
        {
            _peopleService = peopleService;
            _logger = logger;
        }
        public async Task<Unit> Handle(DeleteDeliveryPersonCommand request, CancellationToken cancellationToken)
        {

            try
            {
                _logger.LogInformation("Start Delete Delivery Person");

                await _peopleService.RemoveAsync(request.CNH);

                _logger.LogInformation("Ended Delete Delivery Person");

                return Unit.Value;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Delete Delivery Person - Error {ex.Message}");
                throw new Exception(ex.Message);
            }           
        }
    }
}
