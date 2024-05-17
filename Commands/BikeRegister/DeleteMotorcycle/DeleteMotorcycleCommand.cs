
using MediatR;
using registerAPI.Services;

namespace registerAPI.Commands.City.DeleteMotorcycle
{
  
    public class DeleteMotorcycleCommand : IRequest    
    {
        public string MotorcycleLicense { get; set; }
    }
}
