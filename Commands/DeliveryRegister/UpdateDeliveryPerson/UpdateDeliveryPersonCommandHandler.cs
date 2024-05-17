using MediatR;
using registerAPI.Commands.Person.CreateDeliveryPerson;
using registerAPI.Services.Interfaces;

namespace registerAPI.Commands.DeliveryRegister.UpdateDeliveryPerson
{
    public class UpdateDeliveryPersonCommandHandler : IRequestHandler<UpdateDeliveryPersonCommand, string>
    {
        private ILogger<UpdateDeliveryPersonCommandHandler> _logger;
        private IDeliveryPersonService _deliveryPersonService;
        private IMediator _mediator;
        public UpdateDeliveryPersonCommandHandler(ILogger<UpdateDeliveryPersonCommandHandler> logger, IDeliveryPersonService deliveryPersonService, IMediator mediator)
        {
            _logger = logger;
            _deliveryPersonService = deliveryPersonService;
            _mediator = mediator;

        }

        public async Task<string> Handle(UpdateDeliveryPersonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Start Update Delivery Person");

                var existCNH = await _deliveryPersonService.GetByCnh(request.CNH);

                if (existCNH is null)
                    throw new ArgumentException("CNH não encontrada para atualizar");

                if (!request.CnhPhoto.ContentType.Contains(".png") || request.CnhPhoto.ContentType.Contains("bmp"))
                    throw new ArgumentException("Formato inválido");

                await SavePhoto(request.CnhPhoto.FileName, request.CNH, request.CnhPhoto);

                return "Atualizado com sucesso";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Update Delivery - Erro: {ex.Message}");

                if (ex is ArgumentException)
                    throw new ArgumentException(ex.Message);

                throw new Exception("Erro ao atualizar");

            }           
        }

        public async Task<Unit> SavePhoto(string fileName, int cnh, IFormFile photo)
        {
            var filePath = Path.Combine("Storage", $"{fileName}-{cnh}");
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            photo.CopyTo(fileStream);

            return Unit.Value;
        }
    }
}
