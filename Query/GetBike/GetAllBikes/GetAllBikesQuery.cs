using MediatR;

namespace registerAPI.Query.GetBike.GetAllBikes
{
    using registerAPI.Entity;
    public class GetAllBikesQuery : IRequest<IEnumerable<BikeRegister>>
    {

    }
}
