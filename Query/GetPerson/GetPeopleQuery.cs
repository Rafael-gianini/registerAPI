using MediatR;
using registerAPI.Entity;
using registerAPI.Services;

namespace registerAPI.Query.GetPerson
{
    public class GetPeopleQuery : IRequest<IEnumerable<People>>
    {
    }
}
