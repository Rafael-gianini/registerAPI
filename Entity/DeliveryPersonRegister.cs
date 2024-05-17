using MongoDB.Bson.Serialization.Attributes;

namespace registerAPI.Entity
{
    public class DeliveryPersonRegister
    {
        [BsonElement("id")]
        public Guid Id { get; set; } = Guid.NewGuid();
        [BsonElement("identifyer")]
        public string? Identifyer { get; set; }
        [BsonElement("name")]
        public string? Name { get; set; }
        [BsonElement("cnpj")]
        public string? CNPJ { get; set; } 
        [BsonElement("dateOfBirth")]
        public DateOnly DateOfBirth { get; set; }
        [BsonElement("cnh")] 
        public int CNH { get; set;}
        [BsonElement("typeCNH")]
        public string? TypeCNH { get; set; }
        [BsonElement("fileName")]
        public string? PhotoName { get; set; }
    }

   
}
