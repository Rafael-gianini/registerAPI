using MediatR;
using registerAPI.Commands.RentedMotorcycle.UpdateRental;
using registerAPI.Services;
using registerAPI.Services.Interfaces;

namespace registerAPI.Commands.RentedMotorcycle.UpdateRental
{
    public class UpdateRentalCommandHandler : IRequestHandler<UpdateRentalCommand, string>
    {
        private readonly IInformationRentedMotorcycleService _informationRentedMotorcycleService;
        private readonly ILogger<InformationRentedMotorcycleService> _logger;
        public UpdateRentalCommandHandler(IInformationRentedMotorcycleService informationRentedMotorcycleService, ILogger<InformationRentedMotorcycleService> logger)
        {
            _informationRentedMotorcycleService = informationRentedMotorcycleService;
            _logger = logger;

        }

        public async Task<string> Handle(UpdateRentalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Start Updte Rental");

                var licensePlate = request.CloseRental.LicensePlate.ToUpper();

                if (request.CloseRental.DateDevolution.HasValue.ToString() is null)
                    throw new ArgumentException("Data não pode ser vazia");

                var rental = await _informationRentedMotorcycleService.GetByLicense(licensePlate);
              
                var trafficTicket = await CalculetedTrafficTicket(request.CloseRental.DateDevolution, rental.EstimatedDevolutionDate, rental.TypePlan);

                rental.DateDevolution = request.CloseRental.DateDevolution;
                rental.OpenRental = false;
                rental.ValueTrafficTicket = trafficTicket;

                await _informationRentedMotorcycleService.UpdateAsync(licensePlate, rental);

                _logger.LogInformation("Ended Update Rental");

                return "Atualizado com sucesso";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Update Rental - Error {ex.Message}");

                if (ex is ArgumentException)
                    throw new ArgumentException(ex.Message);

                throw new Exception("Erro ao autualzar!");

            }           
        }

        public async Task<double> CalculetedTrafficTicket(DateOnly? dateDevolution, DateOnly estimatedDevolutionDate, string? typePlan)
        {
            var trafficTicket = 0;
            double days = dateDevolution.HasValue ? dateDevolution.Value.Day - estimatedDevolutionDate.Day : 0;

            if (typePlan.Contains("7"))
            {
                if (days > 0)
                {
                    return (days * 50) + 30;
                }
                else return trafficTicket = (int)(30 * -0.20 * days) + 30;
                
            }
            else if (typePlan.Contains("15"))
            {
                if (days > 0)
                {
                    return (days * 50) + 28;
                }
                else return trafficTicket = (int)(28 * -0.40 * days) + 28;

            }
            else if (typePlan.Contains("30"))
            {
                if (days > 0)
                {
                    return (days * 50) + 22;
                }
                else return trafficTicket = (int)(22 * -0.50 * days) + 22;

            }
            else if (typePlan.Contains("45"))
            { 
                if (days > 0)
                {
                    return (days * 50) + 20;
                }
                else return trafficTicket = (int)(20 * -0.50 * days) + 20;

            }
            else if (typePlan.Contains("50"))
            {
                if (days > 0)
                {
                    return (days * 50) + 18;
                }
                else return trafficTicket = (int)(18 * -0.50 * days) + 18;

            }
          
            return await Task.FromResult(trafficTicket);
        }
    }
}
