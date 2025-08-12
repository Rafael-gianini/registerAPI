using MediatR;

namespace registerAPI.Commands.City
{
    using registerAPI.Entity;
    public class CreateOrUpdateCityCommand : IRequest
    {

        public CreateOrUpdateCityCommand(City city)
        {
            City = city;
        }
        public City City { get; set; }
    }
}
