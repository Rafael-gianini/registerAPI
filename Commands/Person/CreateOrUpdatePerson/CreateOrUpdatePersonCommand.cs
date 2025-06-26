using MediatR;
using registerAPI.Entity;

namespace registerAPI.Commands.Person.CreateOrUpdatePerson
{
    public class CreateOrUpdatePersonCommand : IRequest
    {
        public CreateOrUpdatePersonCommand(People people)
        {
            People = people;

        }
        public People People { get; set; }
    }
}
