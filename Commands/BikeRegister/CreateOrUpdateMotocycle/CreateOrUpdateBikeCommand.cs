using MediatR;

namespace registerAPI.Commands.City.CreateOrUpdateMotocycle
{
    using registerAPI.Entity;
    public class CreateOrUpdateBikeCommand : IRequest
    {

        public CreateOrUpdateBikeCommand(BikeRegister bike) => Bike = bike;
        public BikeRegister Bike { get; set; }
    }
}
