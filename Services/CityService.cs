using Microsoft.Extensions.Options;
using MongoDB.Driver;
using registerAPI.Entity;

namespace registerAPI.Services
{
    public class CityService
    {

        private readonly IMongoCollection<City> _cityCollection;

        public CityService(IOptions<ConnectionMongo> cityService)
        {
            var mongoClient = new MongoClient(cityService.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(cityService.Value.DatabaseName);

            _cityCollection = mongoDatabase.GetCollection<City>(cityService.Value.CityCollectionName);
        }

        public async Task<List<City>> GetAsync() =>
            await _cityCollection.Find(x => true).ToListAsync();

        public async Task<City> GetById(Guid id) =>
            await _cityCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(City people) =>
            await _cityCollection.InsertOneAsync(people);

        public async Task UpdateAsync(Guid id, City people) =>
            await _cityCollection.ReplaceOneAsync(x => x.Id == id, people);

        public async Task RemoveAsync(Guid id) =>
            await _cityCollection.DeleteOneAsync(x => x.Id == id);

    }
}
