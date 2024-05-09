
using MediatR;
using registerAPI.Services;

namespace registerAPI.Commands.City.DeleteMotorcycle
{
  
    public class DeleteMotocycleCommand : IRequest    
    {
        public string AliasKey { get; set; }
    }
}
