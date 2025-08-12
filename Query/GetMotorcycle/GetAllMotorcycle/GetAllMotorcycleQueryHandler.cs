using MediatR;
using registerAPI.Services;

namespace registerAPI.Query.GetBike.GetAllBikes
{
    using registerAPI.Entity;
    using registerAPI.Services.Interfaces;

    public class GetAllMotorcycleQueryHandler : IRequestHandler<GetAllMotorcycleQuery, IEnumerable<MotorcycleRegister>>
    {
        private readonly IMotorcycleService _bikeService;
        private readonly ILogger<GetAllMotorcycleQueryHandler> _logger;
        public GetAllMotorcycleQueryHandler(IMotorcycleService bikeService, ILogger<GetAllMotorcycleQueryHandler> logger)
        {
            _bikeService = bikeService;
            _logger = logger;

        }

        public async Task<IEnumerable<MotorcycleRegister>> Handle(GetAllMotorcycleQuery request, CancellationToken cancellationToken)
        {

            try
            {
                _logger.LogInformation("Start Get All Motorcycles");

                var listBike = await _bikeService.GetAsync();

                _logger.LogInformation("Ended Get All Motorcycles");

                return listBike;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get All Motorcycles - Error: {ex.Message}");
                throw new Exception("Erro ao buscar motos cadastradas");
            }
            throw new NotImplementedException();
        }
    }
}
