using MediatR;
using registerAPI.Entity;

namespace registerAPI.Query.GetBike.GetBikeLicense
{
    public class GetMotorcycleLicenseQuery : IRequest<MotorcycleRegister>
    {
        public string? LicensePlate { get; set; }
    }
}
