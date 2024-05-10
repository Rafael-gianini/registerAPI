using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using registerAPI.Entity;
using System.Security.Cryptography;


namespace registerAPI.Services
{
    public class DeliveryPersonService 
    {
        private readonly IMongoCollection<DeliveryPersonRegister> _deliveryPersonCollection;

        public DeliveryPersonService(IOptions<ConnectionMongo> peopleService)
        {
            var mongoClient = new MongoClient(peopleService.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(peopleService.Value.DatabaseName);
         
            _deliveryPersonCollection = mongoDatabase.GetCollection<DeliveryPersonRegister>(peopleService.Value.DeliveryPersonCollectionName);
        }

        public async Task<List<DeliveryPersonRegister>> GetAsyncByPage(int page, int pageSize) => 
            await _deliveryPersonCollection.Find(new BsonDocument()).Skip((page - 1) * pageSize).Limit(pageSize).ToListAsync();

        public async Task<List<DeliveryPersonRegister>> GetAllAsync() =>
            await _deliveryPersonCollection.Find(new BsonDocument()).ToListAsync();

        public async Task<DeliveryPersonRegister> GetByCnh(double cnh)
        {
            var filter = Builders<DeliveryPersonRegister>.Filter.Eq("cnh", cnh);
            var deliveryPersonregistred = await _deliveryPersonCollection.Find(filter).FirstOrDefaultAsync();
            return deliveryPersonregistred;
        }

        public async Task CreateAsync(DeliveryPersonRegister people) =>
            await _deliveryPersonCollection.InsertOneAsync(people);

        public async Task UpdateAsync(int cnh, DeliveryPersonRegister people) =>
            await _deliveryPersonCollection.ReplaceOneAsync(x => x.CNH == cnh, people);

        public async Task RemoveAsync(int cnh) => 
            await _deliveryPersonCollection.DeleteOneAsync(x => x.CNH == cnh);  
    }
}
