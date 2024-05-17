

using MediatR;

namespace registerAPI.Commands.Person.DeletePerson
{
    public class DeleteDeliveryPersonCommand : IRequest<string>
    {
        public int CNH { get; set; }
    }
}
