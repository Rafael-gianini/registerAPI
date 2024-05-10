using Microsoft.Extensions.Options;
using MongoDB.Driver;
using registerAPI.Entity;

namespace registerAPI.Services
{
    public class InformationRentedMotorcycleService 
    {
        private readonly IMongoCollection<InformationRentedMotorcycle> _informationRentedMotorcycleCollection;

        public InformationRentedMotorcycleService(IOptions<ConnectionMongo> rentedService)
        {
            var mongoClient = new MongoClient(rentedService.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(rentedService.Value.DatabaseName);

            _informationRentedMotorcycleCollection = mongoDatabase.GetCollection<InformationRentedMotorcycle>(rentedService.Value.InformationRentedMotorcycleCollectionName);
        }

        public async Task<List<InformationRentedMotorcycle>> GetAsync() =>
            await _informationRentedMotorcycleCollection.Find(x => true).ToListAsync();

        public async Task<InformationRentedMotorcycle> GetByLicense(string? bikeLicense) =>
            await _informationRentedMotorcycleCollection.Find(x => x.LicensePlate == bikeLicense).FirstOrDefaultAsync();

        public async Task CreateAsync(InformationRentedMotorcycle bike) =>
            await _informationRentedMotorcycleCollection.InsertOneAsync(bike);

        public async Task UpdateAsync(string bikeLicense, InformationRentedMotorcycle bike) =>
            await _informationRentedMotorcycleCollection.ReplaceOneAsync(x => x.LicensePlate == bikeLicense, bike);

        public async Task RemoveAsync(string bikeLicense) =>
            await _informationRentedMotorcycleCollection.DeleteOneAsync(x => x.LicensePlate == bikeLicense);

    }
}
