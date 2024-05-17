using MediatR;

namespace registerAPI.Commands.City.CreateOrUpdateMotocycle
{
    using registerAPI.Entity;
    public class CreateMotorcycleCommand : IRequest
    {

        public CreateMotorcycleCommand(MotorcycleRegister bike) => Bike = bike;
        public MotorcycleRegister Bike { get; set; }
    }
}
