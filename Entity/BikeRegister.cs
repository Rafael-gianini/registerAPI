using MongoDB.Bson.Serialization.Attributes;

namespace registerAPI.Entity
{
    public class BikeRegister
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


}
