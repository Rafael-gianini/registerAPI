using MediatR;
using registerAPI.Entity;
using registerAPI.Services;

namespace registerAPI.Query.GetDelivery.GetAllDeliveryPeople
{
    public class GetAllDeliveryPeopleQuery : IRequest<IEnumerable<DeliveryPersonRegister>>
    {

    }
}
