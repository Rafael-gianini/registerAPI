using MediatR;
using registerAPI.Entity;

namespace registerAPI.Commands.Person
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
