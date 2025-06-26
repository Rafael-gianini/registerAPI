using System.Security.Principal;

namespace registerAPI.Entity
{
    public class ConnectionMongo
    {
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
        public string? PeopleCollectionName { get; set; }
        public string? CityCollectionName { get; set; }
    }
}
