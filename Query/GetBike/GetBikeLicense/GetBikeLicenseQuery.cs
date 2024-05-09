using MediatR;
using registerAPI.Entity;

namespace registerAPI.Query.GetBike.GetBikeLicense
{
    public class GetBikeLicenseQuery : IRequest<BikeRegister>
    {
        public string? LicensePlate { get; set; }
    }
}
