using MediatR;

namespace registerAPI.Commands.BikeRegister.UpdateMotorcycle
{
    using registerAPI.Entity;
    public class UpdateMotorcycleCommand : IRequest<string>
    {
        public UpdateMotorcycleCommand(UpdateMotorcycle updateMotorcycle) => Moto = updateMotorcycle;
        public UpdateMotorcycle Moto { get; set; }
    }
}
