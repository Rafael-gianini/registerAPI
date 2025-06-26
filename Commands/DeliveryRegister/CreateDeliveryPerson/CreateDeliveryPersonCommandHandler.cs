using Amazon.Runtime.Internal;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using registerAPI.Entity;
using registerAPI.Services;
using registerAPI.Services.Interfaces;
using System.Globalization;

namespace registerAPI.Commands.Person.CreateDeliveryPerson
{
    public class CreateDeliveryPersonCommandHandler : IRequestHandler<CreateDeliveryPersonCommand, string>
    {
        private readonly IDeliveryPersonService _deliveryPersonService;
        private readonly ILogger<CreateDeliveryPersonCommandHandler> _logger;
        private readonly IMapper _mapper;
        public CreateDeliveryPersonCommandHandler(IDeliveryPersonService deliveryPersonService, ILogger<CreateDeliveryPersonCommandHandler> logger, IMapper mapper)
        {
            _deliveryPersonService = deliveryPersonService;
            _logger = logger;
            _mapper = mapper;

        }

        public async Task<string> Handle(CreateDeliveryPersonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Start Create Delivery Person");

                var typeCNH = request.TypeCNH?.ToUpper();
                request.TypeCNH = typeCNH;
                
                //if (!request.CnhPhoto.ContentType.Contains(".png") || request.CnhPhoto.ContentType.Contains("bmp"))
                    //throw new ArgumentException("Formato inválido");

                await SavePhoto(request.CnhPhoto.FileName, request.CNH, request.CnhPhoto);
                
                var existsDeliveryPerson = await _deliveryPersonService.GetByCnh(request.CNH);

                if (existsDeliveryPerson is not null)
                    throw new ArgumentException("CNH já cadastrada");

                if (!typeCNH.Contains("A") && !typeCNH.Contains("B") && !typeCNH.Contains("AB"))
                    throw new ArgumentException("Tipo de CNH inválida!");

                var mapperForm = _mapper.Map<DeliveryPersonRegister>(request);

                var dateFormated = await VerifyDate(request.DateOfBirth);
                mapperForm.DateOfBirth = dateFormated;
                mapperForm.PhotoName = $"{request.CNH}-{request.CnhPhoto.FileName}";
               
                await _deliveryPersonService.CreateAsync(mapperForm);

                _logger.LogInformation("Ended Create Delivery Person");

                return "Entregador cadastrado com sucesso";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Create Delivery Person - Error {ex.Message}");

                if (ex is ArgumentException)
                    throw new ArgumentException(ex.Message);

                throw new Exception("Erro ao cadastrar");
            }
        }

        public Task<Unit> SavePhoto(string fileName, int cnh, IFormFile photo)
        {
            
            var filePath = Path.Combine("Storage", $"{cnh}-{fileName}");
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            photo.CopyTo(fileStream);

            return Task.FromResult(Unit.Value);
        }

        public Task<DateOnly> VerifyDate(string? date)
        {

            var array = date.Split('/');

            var day = array[0];
            var month = array[1];
            var year = array[2];

            var dateFormated = $"{month}-{day}-{year}";
            
            return Task.FromResult( DateOnly.Parse(dateFormated));

        }
    }
}
