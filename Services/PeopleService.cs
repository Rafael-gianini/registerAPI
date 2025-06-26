using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using registerAPI.Entity;


namespace registerAPI.Services
{
    public class PeopleService
    {
        private readonly IMongoCollection<People> _peopleCollection;

        public PeopleService(IOptions<ConnectionMongo> peopleService)
        {
            var mongoClient = new MongoClient(peopleService.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(peopleService.Value.DatabaseName);

            _peopleCollection = mongoDatabase.GetCollection<People>(peopleService.Value.PeopleCollectionName);
        }

        public async Task<List<People>> GetAsyncByPage(int page, int pageSize) => 
            await _peopleCollection.Find(new BsonDocument()).Skip((page - 1) * pageSize).Limit(pageSize).ToListAsync();

        public async Task<List<People>> GetAllAsync() =>
            await _peopleCollection.Find(new BsonDocument()).ToListAsync();

        public async Task<People> GetById(Guid id) =>
            await _peopleCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(People people) =>
            await _peopleCollection.InsertOneAsync(people);

        public async Task UpdateAsync(Guid id, People people) =>
            await _peopleCollection.ReplaceOneAsync(x => x.Id == id, people);

        public async Task RemoveAsync(Guid id) => 
            await _peopleCollection.DeleteOneAsync(x => x.Id == id);  
    }
}
