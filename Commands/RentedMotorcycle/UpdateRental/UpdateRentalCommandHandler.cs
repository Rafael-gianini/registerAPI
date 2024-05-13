using MediatR;
using registerAPI.Commands.RentedMotorcycle.UpdateLease;
using registerAPI.Services;
using registerAPI.Services.Interfaces;

namespace registerAPI.Commands.RentedMotorcycle.UpdateRental
{
    public class UpdateRentalCommandHandler : IRequestHandler<UpdateRentalCommand>
    {
        private readonly IInformationRentedMotorcycleService _informationRentedMotorcycleService;
        private readonly ILogger<InformationRentedMotorcycleService> _logger;
        public UpdateRentalCommandHandler(IInformationRentedMotorcycleService informationRentedMotorcycleService, ILogger<InformationRentedMotorcycleService> logger)
        {
            _informationRentedMotorcycleService = informationRentedMotorcycleService;
            _logger = logger;

        }

        public async Task<Unit> Handle(UpdateRentalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Start Updte Rental");

                if (request.CloseRental.DateDevolution.HasValue.ToString() is null)
                    throw new ArgumentException("Data não pode ser vazia");

                var rental = await _informationRentedMotorcycleService.GetByLicense(request.CloseRental.LicensePlate);

                if (request.CloseRental.DateDevolution > rental.EstimatedDevolutionDate)
                    await CalculetedTrafficTicket(request.CloseRental.DateDevolution, rental.EstimatedDevolutionDate, rental.TypePlan);

                rental.DateDevolution = request.CloseRental.DateDevolution;
                rental.OpenRental = false;

                _logger.LogInformation("Ended Update Rental");

                return Unit.Value;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Update Rental - Error {ex.Message}");
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<string> CalculetedTrafficTicket(DateOnly? dateDevolution, DateOnly estimatedDevolutionDate, string typePlan)
        {
            
            var trafficTicket = dateDevolution.Value.Day - estimatedDevolutionDate.Day;



            return await Task.FromResult("");
        }
    }
}
