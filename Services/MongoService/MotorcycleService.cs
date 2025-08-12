using Microsoft.Extensions.Options;
using MongoDB.Driver;
using registerAPI.Entity;
using registerAPI.Services.Interfaces;

namespace registerAPI.Services
{
    public class MotorcycleService : IMotorcycleService
    {
        //private readonly IOptions<ConnectionMongo> _bikeService;
        private readonly IMongoCollection<MotorcycleRegister> _bikeCollection;

        public MotorcycleService(IOptions<ConnectionMongo> bikeService)
        {
            var mongoClient = new MongoClient(bikeService.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(bikeService.Value.DatabaseName);

            _bikeCollection = mongoDatabase.GetCollection<MotorcycleRegister>(bikeService.Value.BikeRegisterCollectionName);
            
        }

        public async Task<List<MotorcycleRegister>> GetAsync() =>
            await _bikeCollection.Find(x => true).ToListAsync();

        public async Task<MotorcycleRegister> GetByLicense(string? bikeLicense) =>
            await _bikeCollection.Find(x => x.BikeLicensePlate == bikeLicense).FirstOrDefaultAsync();

        public async Task CreateAsync(MotorcycleRegister bike) =>
            await _bikeCollection.InsertOneAsync(bike);

        public async Task UpdateAsync(string? bikeLicense, MotorcycleRegister bike) =>
            await _bikeCollection.ReplaceOneAsync(x => x.BikeLicensePlate == bikeLicense, bike);

        public async Task RemoveAsync(string bikeLicense) =>
            await _bikeCollection.DeleteOneAsync(x => x.BikeLicensePlate == bikeLicense);

    }
}
