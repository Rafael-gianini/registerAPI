using MediatR;

namespace registerAPI.Commands.RentedMotorcycle.DeleteLease
{
    public class DeleteLeaseCommand : IRequest
    {
        public string? BikeLicense { get; set; }
    }
}
