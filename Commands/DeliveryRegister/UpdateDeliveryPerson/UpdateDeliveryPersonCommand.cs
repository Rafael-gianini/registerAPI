using MediatR;

namespace registerAPI.Commands.DeliveryRegister.UpdateDeliveryPerson
{
    public class UpdateDeliveryPersonCommand : IRequest<string>
    {
       
        public int CNH { get; set; }      
        public IFormFile CnhPhoto { get; set; }
    }
}
