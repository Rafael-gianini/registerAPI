using System.Security.Principal;

namespace registerAPI.Entity
{
    public class ConnectionMongo : IConnectionsMongo
    {

        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
<<<<<<< HEAD
        public string? PeopleCollectionName { get; set; }
        public string? CityCollectionName { get; set; }
=======
        public string? DeliveryPersonCollectionName { get; set; }
        public string? BikeRegisterCollectionName { get; set; }
        public string? RentedMotorcycleCollectionName { get; set; }
        public string? InformationRentedMotorcycleCollectionName { get; set; }
    }

    public interface IConnectionsMongo
    {
        public static string? ConnectionString { get; set; }
        public static string? DatabaseName { get; set; }
        public static string? DeliveryPersonCollectionName { get; set; }
        public static string? BikeRegisterCollectionName { get; set; }
        public static string? RentedMotorcycleCollectionName { get; set; }
        public static string? InformationRentedMotorcycleCollectionName { get; set; }
>>>>>>> 67066e05a104e75abf879380f5adc7005ddf4310
    }
}
