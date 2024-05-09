

using MediatR;

namespace registerAPI.Commands.RentedMotorcycle.CreateLocation
{
    using registerAPI.Entity;
    public class CreateLocationCommand : IRequest
    {
        public CreateLocationCommand(RentedMotorcycle rentendMotorcycle) => RentendMotorcycle = rentendMotorcycle;
        
        public RentedMotorcycle RentendMotorcycle { get; set; }
    }
}
