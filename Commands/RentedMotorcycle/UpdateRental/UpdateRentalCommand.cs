using MediatR;

namespace registerAPI.Commands.RentedMotorcycle.UpdateRental
{
    public class UpdateRentalCommand : IRequest<string>
    {
        public UpdateRentalCommand(CloseRental closeRental)
        {

            CloseRental = closeRental;

        }
        public CloseRental CloseRental { get; set; }
    }

    public class CloseRental
    {
        public int CNH { get; set; }
        public string? LicensePlate { get; set; }
        public DateOnly? DateDevolution { get; set; }
        
    }
}
