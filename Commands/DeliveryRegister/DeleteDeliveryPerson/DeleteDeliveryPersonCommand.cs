

using MediatR;

namespace registerAPI.Commands.Person.DeletePerson
{
    public class DeleteDeliveryPersonCommand : IRequest
    {
        public int CNH { get; set; }
    }
}
