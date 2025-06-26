using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using registerAPI.Entity;

namespace registerAPI.Commands.Person.CreateDeliveryPerson
{
    public class CreateDeliveryPersonCommand : IRequest<string>
    {
       
        public string? Identifyer { get; set; }       
        public string? Name { get; set; }       
        public string? CNPJ { get; set; }
        public string? DateOfBirth { get; set; } 
        public int CNH { get; set; }      
        public string? TypeCNH { get; set; }
        public IFormFile CnhPhoto { get; set; }
    }
}
