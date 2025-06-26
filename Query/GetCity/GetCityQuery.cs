using MediatR;
using registerAPI.Entity;

namespace registerAPI.Query.GetCity
{
    public class GetCityQuery : IRequest<IEnumerable<City>>
    {

    }
}
