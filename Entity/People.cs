using MongoDB.Bson.Serialization.Attributes;

namespace registerAPI.Entity
{
    public class People
    {
        [BsonElement("id")]
        public Guid? Id { get; set; }
        [BsonElement("email")]
        public string? Email { get; set; }
        [BsonElement("fullName")]
        public string? FullName { get; set; } 
        [BsonElement("cityId")]
        public int CityId { get; set; }
        [BsonElement("countPeople")] 
        public int CountPeople { get; set;}
    }
}
