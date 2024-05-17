using MongoDB.Bson.Serialization.Attributes;

namespace registerAPI.Entity
{
    public class MotorcycleRegister
    {

        [BsonElement("id")]
        public Guid Id  { get; set; }
        [BsonElement("bikeLicensePlate")]
        public string? BikeLicensePlate { get; set; }
        [BsonElement("yearBike")]
        public int YearBike { get; set; }
        [BsonElement("modelBike")]
        public string? ModelBike { get; set; }
    }

    public class UpdateMotorcycle
    {
        public string? WrongBikeLicensePlate { get; set; }
        public string? UpdategBikeLicensePlate { get; set; }
        
    }
}
