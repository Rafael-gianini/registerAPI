using MediatR;
using registerAPI.Entity;

namespace registerAPI.Query.GetForRent
{
    public class GetPlansForRentQuery : IRequest<Dictionary<int, string>>
    {       
    }
}
