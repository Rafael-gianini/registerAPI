using MediatR;
using registerAPI.Entity;
using registerAPI.Query.GetForRent;
using registerAPI.Services;

namespace registerAPI.Commands.RentedMotorcycle.CreateLocation
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand>
    {
        private readonly IMediator _mediator;
        private readonly RentedService _rentedService;
        private readonly BikeService _bikeService;
        private readonly DeliveryPersonService _deliveryPersonService;
        private readonly InformationRentedMotorcycleService _informationRentedMotorcycleService;
        private readonly ILogger<CreateLocationCommandHandler> _logger;

        public CreateLocationCommandHandler(
            RentedService rentedService, 
            IMediator mediator,
            BikeService bikeService,
            DeliveryPersonService deliveryPersonService,
            InformationRentedMotorcycleService informationRentedMotorcycleService,
            ILogger<CreateLocationCommandHandler> logger)
        {
            _rentedService = rentedService;
            _mediator = mediator;
            _bikeService = bikeService;
            _deliveryPersonService = deliveryPersonService;
            _informationRentedMotorcycleService = informationRentedMotorcycleService;
            _logger = logger;
         }

        public async Task<Unit> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            try
            {


                var choosenPlan = request.RentendMotorcycle.ChooseYourPlan;
                var motorcycleLicense = request.RentendMotorcycle.LicensePlate?.ToUpper();
                request.RentendMotorcycle.LicensePlate = motorcycleLicense;

                var listPlan = await _mediator.Send(new GetPlansForRentQuery(), cancellationToken);

                var value = listPlan.Where(x => x.Key == choosenPlan).FirstOrDefault().Value;

                var confirmMotocycleRegister = await _bikeService.GetByLicense(motorcycleLicense);

                if (confirmMotocycleRegister is null)
                    throw new ArgumentException("Placa não encontrada nos registros! Verifique se digitou corretamente!");

                var confirmCNHRegister = await _deliveryPersonService.GetByCnh(request.RentendMotorcycle.CNH);

                if (confirmCNHRegister is null)
                    throw new ArgumentException("CNH não encontrada nos registros! Verifique se digitou corretamente!");
                else
                {
                    var confirmTypeCNH = confirmCNHRegister.TypeCNH.Contains("A") || confirmCNHRegister.TypeCNH.Contains("B") || confirmCNHRegister.TypeCNH.Contains("AB");
                    if (!confirmTypeCNH)
                        throw new ArgumentException("Tipo de CNH não permitido!");
                }

                var confirmDate = request.RentendMotorcycle.StartPeriod < request.RentendMotorcycle.EndPeriod;

                if (!confirmDate)
                    throw new Exception("A data final não pode ser menor que a inicial!");
                else if (request.RentendMotorcycle.StartPeriod.Day.ToString() is null || request.RentendMotorcycle.EndPeriod.Day.ToString() is null)
                {
                    throw new Exception("Data incorreta!");

                }
                var quantityDays = request.RentendMotorcycle.EndPeriod.AddDays(1).Day - request.RentendMotorcycle.StartPeriod.AddDays(1).Day;

                var valuePlan = await CalculetedValuePlan(quantityDays, value);

                var information = new InformationRentedMotorcycle
                {
                    CNH = request.RentendMotorcycle.CNH,
                    LicensePlate = motorcycleLicense,
                    TypePlan = value,
                    QuantityDays = quantityDays,
                    ValuePlan = valuePlan.ToString("C")
                };

                await _informationRentedMotorcycleService.CreateAsync(information);

                await _rentedService.CreateAsync(request.RentendMotorcycle);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        public async Task<double> CalculetedValuePlan(int quantityDays, string value)
        {
            if (value.Contains("30"))
            {
                return await Task.FromResult(quantityDays * 30);
            }
            else if (value.Contains("28"))
            {
               return await Task.FromResult(quantityDays * 28);
            }
            else if (value.Contains("22"))
            {
                return await Task.FromResult(quantityDays * 22);
            }
            else if (value.Contains("20"))
            {
                return await Task.FromResult(quantityDays * 20);
            }
            else if (value.Contains("18"))
            {
                return await Task.FromResult(quantityDays * 18);
            }
            return await Task.FromResult(0);
        }
    }
}
