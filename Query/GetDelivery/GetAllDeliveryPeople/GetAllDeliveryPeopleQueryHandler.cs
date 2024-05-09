using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using registerAPI.Entity;
using registerAPI.Services;

namespace registerAPI.Query.GetDelivery.GetAllDeliveryPeople
{
    public class GetAllDeliveryPeopleQueryHandler : IRequestHandler<GetAllDeliveryPeopleQuery, IEnumerable<DeliveryPersonRegister>>
    {
        private readonly DeliveryPersonService _deliveryPersonService;
        private readonly ILogger<GetAllDeliveryPeopleQueryHandler> _logger;
        public GetAllDeliveryPeopleQueryHandler(DeliveryPersonService deliveryPersonService, ILogger<GetAllDeliveryPeopleQueryHandler> logger)
        {
            _deliveryPersonService = deliveryPersonService;
            _logger = logger;
        }
        public async Task<IEnumerable<DeliveryPersonRegister>> Handle(GetAllDeliveryPeopleQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Start Delevery Person Register");

                var listDeliveryPerson = await _deliveryPersonService.GetAllAsync();

                _logger.LogInformation("Ended Delevery Person Register");

                return listDeliveryPerson;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get All Delivery People - Error {ex.Message}");
                throw new Exception(ex.Message);
            }

        }
    }
}

