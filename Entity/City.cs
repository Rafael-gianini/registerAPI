using MongoDB.Bson.Serialization.Attributes;

namespace registerAPI.Entity
{
    public class City
    {
        [BsonElement("id")]
        public Guid Id { get; set; }
        [BsonElement("cityName")]
        public string? CityName { get; set; }
        [BsonElement("state")]
        public string? State { get; set; }
    }
}
