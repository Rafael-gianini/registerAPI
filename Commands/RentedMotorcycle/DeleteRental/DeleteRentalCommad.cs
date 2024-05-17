using MediatR;

namespace registerAPI.Commands.RentedMotorcycle.DeleteRental
{
    public class DeleteRentalCommand : IRequest<string>
    {
        public string? BikeLicense { get; set; }
    }
}
