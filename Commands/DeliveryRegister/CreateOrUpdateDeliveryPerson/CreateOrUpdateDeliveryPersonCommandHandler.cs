using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using registerAPI.Entity;
using registerAPI.Services;
using registerAPI.Services.Interfaces;

namespace registerAPI.Commands.Person.CreateOrUpdatePerson
{
    public class CreateOrUpdateDeliveryPersonCommandHandler : IRequestHandler<CreateOrUpdateDeliveryPersonCommand>
    {
        private readonly IDeliveryPersonService _deliveryPersonService;
        private readonly ILogger<CreateOrUpdateDeliveryPersonCommandHandler> _logger;
        public CreateOrUpdateDeliveryPersonCommandHandler(IDeliveryPersonService deliveryPersonService, ILogger<CreateOrUpdateDeliveryPersonCommandHandler> logger)
        {
            _deliveryPersonService = deliveryPersonService;
            _logger = logger;

        }

        public async Task<Unit> Handle(CreateOrUpdateDeliveryPersonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Start Create Delivery Person");

                request.DeliveryPersonRegister.Id = Guid.NewGuid();
                var typeCNH = request.DeliveryPersonRegister.TypeCNH?.ToUpper();
                request.DeliveryPersonRegister.TypeCNH = typeCNH;

                var existsDeliveryPerson = await _deliveryPersonService.GetByCnh(request.DeliveryPersonRegister.CNH);

                if (existsDeliveryPerson is not null)
                    throw new ArgumentException("CNH já cadastrada");

                if (!typeCNH.Contains("A") && !typeCNH.Contains("B") && !typeCNH.Contains("AB"))
                    throw new ArgumentException("Tipo de CNH inválida!");

                await _deliveryPersonService.CreateAsync(request.DeliveryPersonRegister);

                _logger.LogInformation("Ended Create Delivery Person");

                return Unit.Value;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Create Delivery Person - Error {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
