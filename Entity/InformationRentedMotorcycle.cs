using MongoDB.Bson.Serialization.Attributes;

namespace registerAPI.Entity
{
    public class InformationRentedMotorcycle
    {
        [BsonElement("id")]
        public int Id { get; set; }
        [BsonElement("cnh")]
        public int CNH { get; set; }
        [BsonElement("licensePlate")]
        public string? LicensePlate { get; set; }
        [BsonElement("TypePlan")]
        public string? TypePlan { get; set; }
        [BsonElement("quantityDays")]
        public int QuantityDays { get; set; }
        [BsonElement("valuePlan")]
        public string? ValuePlan { get; set; }
        [BsonElement("openRental")]
        public bool OpenRental { get; set; }
        [BsonElement("estimatedDateDevolution")]
        public DateOnly EstimatedDevolutionDate { get; set; }
        [BsonElement("dateDevolution")]
        public DateOnly? DateDevolution { get; set; }
    }
}
