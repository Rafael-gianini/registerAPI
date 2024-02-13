using MediatR;
using registerAPI.Entity;
using registerAPI.Services;

namespace registerAPI.Query.GetPerson
{
    public class GetPeopleQueryHandler : IRequestHandler<GetPeopleQuery, IEnumerable<People>>
    {
        private readonly PeopleService _peopleService;
        public GetPeopleQueryHandler(PeopleService peopleService)
        {
            _peopleService = peopleService;
            
        }
        public async Task<IEnumerable<People>> Handle(GetPeopleQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var people = await _peopleService.GetAsync();

                return people;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           
        }
    }
}

