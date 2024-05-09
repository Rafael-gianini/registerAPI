using System.Security.Principal;

namespace registerAPI.Entity
{
    public class ConnectionMongo
    {
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
        public string? DeliveryPersonCollectionName { get; set; }
        public string? BikeRegisterCollectionName { get; set; }
        public string? RentedMotorcycleCollectionName { get; set; }
        public string? InformationRentedMotorcycleCollectionName { get; set; }
    }
}
