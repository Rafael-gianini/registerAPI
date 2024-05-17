using MediatR;

namespace registerAPI.Query.GetBike.GetAllBikes
{
    using registerAPI.Entity;
    public class GetAllMotorcycleQuery : IRequest<IEnumerable<MotorcycleRegister>>
    {

    }
}
