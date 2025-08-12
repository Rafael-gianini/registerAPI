using Amazon.Runtime.Internal.Transform;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Security.Cryptography;

namespace registerAPI.Entity
{
    public class RentedMotorcycle
    {
        [BsonElement("id")]
        public Guid Id { get; set; } = Guid.NewGuid();
        [BsonElement("cnh")]
        public int CNH { get; set; }
        [BsonElement("licensePlate")]
        public string? LicensePlate { get; set; }
        [BsonElement("startPeriod")]
        public DateOnly StartPeriod  { get; set; }
        [BsonElement("endPeriod")]
        public DateOnly EndPeriod { get; set; }
        [BsonElement("typeCNH")]
        public string? TypeCNH { get; set; }
        [BsonElement("chooseYourPlan")]
        public int ChooseYourPlan { get; set; }       
    }
    
}
