using MediatR;
using registerAPI.Services;
namespace registerAPI.Commands.City
{
    public class CreateOrUpdateCityCommandHandler : IRequestHandler<CreateOrUpdateCityCommand>
    {
        private readonly CityService _cityService;
        public CreateOrUpdateCityCommandHandler(CityService cityService)
        {
            _cityService = cityService;
            
        }

        public async Task<Unit> Handle(CreateOrUpdateCityCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.City.Id = Guid.NewGuid();

                await _cityService.CreateAsync(request.City);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
