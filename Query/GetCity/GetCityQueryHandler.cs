using MediatR;
using registerAPI.Entity;
using registerAPI.Services;

namespace registerAPI.Query.GetCity
{
    public class GetCityQueryHandler : IRequestHandler<GetCityQuery, IEnumerable<City>>
    {
        private readonly CityService _cityService;
        public GetCityQueryHandler(CityService cityService)
        {
            _cityService = cityService;
        }

        public async Task<IEnumerable<City>> Handle(GetCityQuery request, CancellationToken cancellationToken)
        {

            try
            {
                var citys = await _cityService.GetAsync();

                return citys;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            throw new NotImplementedException();
        }
    }
}
