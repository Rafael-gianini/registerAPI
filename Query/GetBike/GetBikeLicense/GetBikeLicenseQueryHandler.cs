using MediatR;
using registerAPI.Entity;
using registerAPI.Services;

namespace registerAPI.Query.GetBike.GetBikeLicense
{
    public class GetBikeLicenseQueryHandler : IRequestHandler<GetBikeLicenseQuery, BikeRegister>
    {
        private readonly BikeService _bikeService;
        private readonly ILogger<GetBikeLicenseQueryHandler> _logger;
        public GetBikeLicenseQueryHandler(BikeService bikeService, ILogger<GetBikeLicenseQueryHandler> logger)
        {
            _bikeService = bikeService;
            _logger = logger;

        }

        public async Task<BikeRegister> Handle(GetBikeLicenseQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Start Get Motorcycle License");

                var license = request.LicensePlate?.ToUpper();

                var bikeLicense = await _bikeService.GetByLicense(license);

                if (bikeLicense is null)
                    throw new ArgumentException("Placa não cadastrada");

                _logger.LogInformation("Ended Get Motorcycle License");

                return bikeLicense; 
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           
        }
    }
}
