using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
                var page = request.Page;
                var pageSize = request.PageSize;              
                var countPeople = 0;
              
                var people = await _peopleService.GetAsyncByPage(page, pageSize);
                countPeople += people.Count();
               
                if (request.Page == 1 && !request.BackAPI)
                {
                    while (page > 0)
                    {
                        ++page;
                        var peoplePerPage = await _peopleService.GetAsyncByPage(page, pageSize);
                        if (peoplePerPage.Count() == 0)
                            page = 0;
                        else                      
                           countPeople += peoplePerPage.Count();                                                 
                    }
                    people.ForEach(x => x.CountPeople = countPeople);
                }
             
                return people;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           
        }
    }
}

