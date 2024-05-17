using MediatR;
using registerAPI.Entity;
using registerAPI.Services;
using registerAPI.Services.Interfaces;

namespace registerAPI.Query.GetBike.GetBikeLicense
{
    public class GetMotorcycleLicenseQueryHandler : IRequestHandler<GetMotorcycleLicenseQuery, MotorcycleRegister>
    {
        private readonly IMotorcycleService _bikeService;
        private readonly ILogger<GetMotorcycleLicenseQueryHandler> _logger;
        public GetMotorcycleLicenseQueryHandler(IMotorcycleService bikeService, ILogger<GetMotorcycleLicenseQueryHandler> logger)
        {
            _bikeService = bikeService;
            _logger = logger;

        }

        public async Task<MotorcycleRegister> Handle(GetMotorcycleLicenseQuery request, CancellationToken cancellationToken)
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
