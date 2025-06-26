using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using registerAPI.Entity;
using registerAPI.Services;

namespace registerAPI.Commands.Person.CreateOrUpdatePerson
{
    public class CreateOrUpdatePersonCommandHandler : IRequestHandler<CreateOrUpdatePersonCommand>
    {
        private readonly PeopleService _peopleService;
        public CreateOrUpdatePersonCommandHandler(PeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        public async Task<Unit> Handle(CreateOrUpdatePersonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.People.Id = Guid.NewGuid();

                await _peopleService.CreateAsync(request.People);

                return Unit.Value;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
