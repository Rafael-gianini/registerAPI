using MediatR;
using registerAPI.Entity;
using registerAPI.Services;
namespace registerAPI.Commands.City.CreateOrUpdateMotocycle
{
    public class CreateOrUpdateBikeCommandHandler : IRequestHandler<CreateOrUpdateBikeCommand>
    {
        private readonly BikeService _bikeService;
        private readonly ILogger<CreateOrUpdateBikeCommandHandler> _logger;
        public CreateOrUpdateBikeCommandHandler(BikeService bikeService, ILogger<CreateOrUpdateBikeCommandHandler> logger)
        {
            _bikeService = bikeService;
            _logger = logger;
        }

        public async Task<Unit> Handle(CreateOrUpdateBikeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Start Create Motorcycle");

                request.Bike.Id = Guid.NewGuid();
                var bikeLicense = request.Bike.BikeLicensePlate?.ToUpper();
                request.Bike.BikeLicensePlate = bikeLicense;

                var existsBike = await _bikeService.GetByLicense(bikeLicense);

                if (existsBike is not null)
                    throw new ArgumentException("Motocicleta já cadastrada");

                await _bikeService.CreateAsync(request.Bike);

                _logger.LogInformation("Ended Create Motorcycle");


                return Unit.Value;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Create Motorcycle - Error: {ex.Message}");
                throw new ArgumentException("Erro ao cadastrar");
            }

        }
    }
}
