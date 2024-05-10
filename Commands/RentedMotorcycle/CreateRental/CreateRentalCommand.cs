

using MediatR;

namespace registerAPI.Commands.RentedMotorcycle.CreateLocation
{
    using registerAPI.Entity;
    public class CreateRentalCommand : IRequest
    {
        public CreateRentalCommand(RentedMotorcycle rentendMotorcycle) => RentendMotorcycle = rentendMotorcycle;
        
        public RentedMotorcycle RentendMotorcycle { get; set; }
    }
}
