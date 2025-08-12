

using MediatR;
using registerAPI.Services;

namespace registerAPI.Commands.Person.DeletePerson
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
    {
        public readonly PeopleService _peopleService;

        public DeletePersonCommandHandler(PeopleService peopleService)
        {
            _peopleService = peopleService;
        }
        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {

            try
            {
                await _peopleService.RemoveAsync(request.Id);

                return Unit.Value;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }           
        }
    }
}
