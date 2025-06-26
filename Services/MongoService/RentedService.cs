using Microsoft.Extensions.Options;
using MongoDB.Driver;
using registerAPI.Entity;
using registerAPI.Services.Interfaces;


namespace registerAPI.Services
{
    public class RentedService : IRentedService
    {
        private readonly IMongoCollection<RentedMotorcycle> _rentedMotorcycleCollection;

        public RentedService(IOptions<ConnectionMongo> rentedService)
        {
            var mongoClient = new MongoClient(rentedService.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(rentedService.Value.DatabaseName);

            _rentedMotorcycleCollection = mongoDatabase.GetCollection<RentedMotorcycle>(rentedService.Value.RentedMotorcycleCollectionName);
        }

        public async Task<List<RentedMotorcycle>> GetAsync() =>
            await _rentedMotorcycleCollection.Find(x => true).ToListAsync();

        public async Task<RentedMotorcycle> GetByLicense(string? bikeLicense) =>
            await _rentedMotorcycleCollection.Find(x => x.LicensePlate == bikeLicense).FirstOrDefaultAsync();

        public async Task CreateAsync(RentedMotorcycle bike) =>
            await _rentedMotorcycleCollection.InsertOneAsync(bike);

        public async Task UpdateAsync(string bikeLicense, RentedMotorcycle bike) =>
            await _rentedMotorcycleCollection.ReplaceOneAsync(x => x.LicensePlate == bikeLicense, bike);

        public async Task RemoveAsync(string bikeLicense) =>
            await _rentedMotorcycleCollection.DeleteOneAsync(x => x.LicensePlate == bikeLicense);

    }
}
