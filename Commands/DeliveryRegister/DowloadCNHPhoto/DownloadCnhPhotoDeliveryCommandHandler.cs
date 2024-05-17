using MediatR;
using registerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace registerAPI.Commands.DeliveryRegister.DowloadCNHPhoto
{
    public class DownloadCnhPhotoDeliveryCommandHandler : IRequestHandler<DownloadCnhPhotoDeliveryCommand, FileContentResult>
    {
        private readonly ILogger<DownloadCnhPhotoDeliveryCommandHandler> _logger;
        private readonly IDeliveryPersonService _deliveryPersonService; 
        public DownloadCnhPhotoDeliveryCommandHandler(ILogger<DownloadCnhPhotoDeliveryCommandHandler> logger, IDeliveryPersonService deliveryPersonService)
        {
            _logger = logger;
            _deliveryPersonService = deliveryPersonService;
        }

        public async Task<FileContentResult> Handle(DownloadCnhPhotoDeliveryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Start Download CNH Photo");

                
                var allDeliverys = await _deliveryPersonService.GetAllAsync();

                var photoDelivery = allDeliverys.Where(x => x.CNH == request.CNH).FirstOrDefault().PhotoName ?? "";

                if (string.IsNullOrEmpty(photoDelivery))
                    throw new ArgumentException("Entregador não possui foto cadastrada");

                var localStorage = "Storage/" + photoDelivery;
                var dataBytes = File.ReadAllBytes(localStorage);
                var stream = new MemoryStream(dataBytes);

                _logger.LogInformation("Ended Download CNH Photo");

                if (localStorage.Contains("jpg"))
                    return new FileContentResult(dataBytes, "image/jpg");
                else
                return new FileContentResult(dataBytes, "image/png");
                                              
            }
            catch (Exception ex)
            {
                _logger.LogError($"Download CNH Photo - Error {ex.Message}");

                if (ex is ArgumentException)
                    throw new ArgumentException(ex.Message);

                throw new Exception("Erro ao fazer download");
            }           
        }
    }
}
