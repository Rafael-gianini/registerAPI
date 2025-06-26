using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace registerAPI.Commands.DeliveryRegister.DowloadCNHPhoto
{
    public class DownloadCnhPhotoDeliveryCommand : IRequest<FileContentResult>
    {
        public int CNH { get; set; }
    }
}
