

using MediatR;

namespace registerAPI.Commands.RentedMotorcycle.CreateRental
{
    using registerAPI.Entity;
    public class CreateRentalCommand : IRequest<string>
    {
        public CreateRentalCommand(RentedMotorcycle rentendMotorcycle) => RentendMotorcycle = rentendMotorcycle;
        
        public RentedMotorcycle RentendMotorcycle { get; set; }
    }
}
