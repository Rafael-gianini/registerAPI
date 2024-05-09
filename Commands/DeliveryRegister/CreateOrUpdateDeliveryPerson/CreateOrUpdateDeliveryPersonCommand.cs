using MediatR;
using registerAPI.Entity;

namespace registerAPI.Commands.Person.CreateOrUpdatePerson
{
    public class CreateOrUpdateDeliveryPersonCommand : IRequest
    {
        public CreateOrUpdateDeliveryPersonCommand(DeliveryPersonRegister deliveryPersonRegister)
        {
            DeliveryPersonRegister = deliveryPersonRegister;

        }
        public DeliveryPersonRegister DeliveryPersonRegister { get; set; }
    }
}
