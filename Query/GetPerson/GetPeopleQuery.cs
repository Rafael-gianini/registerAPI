using MediatR;
using registerAPI.Entity;
using registerAPI.Services;

namespace registerAPI.Query.GetPerson
{
    public class GetPeopleQuery : IRequest<IEnumerable<People>>
    {
        public int PageSize { get; set; }
        public int Page { get; set; }
        public bool BackAPI { get; set; }
    }
}
