using Microsoft.Extensions.Options;
using MongoDB.Driver;
using registerAPI.Entity;
using registerAPI.Services.Interfaces;

namespace registerAPI.Services
{
    public class BikeService : IBikeService
    {

        private readonly IMongoCollection<BikeRegister> _bikeCollection;

        public BikeService(IOptions<ConnectionMongo> bikeService)
        {
            var mongoClient = new MongoClient(bikeService.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(bikeService.Value.DatabaseName);

            _bikeCollection = mongoDatabase.GetCollection<BikeRegister>(bikeService.Value.BikeRegisterCollectionName);
        }

        public async Task<List<BikeRegister>> GetAsync() =>
            await _bikeCollection.Find(x => true).ToListAsync();

        public async Task<BikeRegister> GetByLicense(string? bikeLicense) =>
            await _bikeCollection.Find(x => x.BikeLicensePlate == bikeLicense).FirstOrDefaultAsync();

        public async Task CreateAsync(BikeRegister bike) =>
            await _bikeCollection.InsertOneAsync(bike);

        public async Task UpdateAsync(string bikeLicense, BikeRegister bike) =>
            await _bikeCollection.ReplaceOneAsync(x => x.BikeLicensePlate == bikeLicense, bike);

        public async Task RemoveAsync(string bikeLicense) =>
            await _bikeCollection.DeleteOneAsync(x => x.BikeLicensePlate == bikeLicense);

    }
}
