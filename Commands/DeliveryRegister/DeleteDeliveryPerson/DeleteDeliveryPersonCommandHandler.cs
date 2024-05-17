

using MediatR;
using registerAPI.Services;
using registerAPI.Services.Interfaces;

namespace registerAPI.Commands.Person.DeletePerson
{
    public class DeleteDeliveryPersonCommandHandler : IRequestHandler<DeleteDeliveryPersonCommand, string>
    {
        private readonly IDeliveryPersonService _peopleService;
        private readonly ILogger<DeleteDeliveryPersonCommandHandler> _logger; 

        public DeleteDeliveryPersonCommandHandler(IDeliveryPersonService peopleService, ILogger<DeleteDeliveryPersonCommandHandler> logger)
        {
            _peopleService = peopleService;
            _logger = logger;
        }
        public async Task<string> Handle(DeleteDeliveryPersonCommand request, CancellationToken cancellationToken)
        {

            try
            {
                _logger.LogInformation("Start Delete Delivery Person");

                await _peopleService.RemoveAsync(request.CNH);

                _logger.LogInformation("Ended Delete Delivery Person");

                return "Deletado com sucesso!";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Delete Delivery Person - Error {ex.Message}");

                if (ex is ArgumentException)
                    throw new ArgumentException(ex.Message);

                throw new Exception("Erro ao deletar!");
            }           
        }
    }
}
