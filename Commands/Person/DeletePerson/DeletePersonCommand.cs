

using MediatR;

namespace registerAPI.Commands.Person.DeletePerson
{
    public class DeletePersonCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
