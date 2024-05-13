using registerAPI.Entity;

namespace registerAPI.Services.Interfaces
{
    public interface IDeliveryPersonService
    {
        public Task<List<DeliveryPersonRegister>> GetAsyncByPage(int page, int pageSize);
        public Task<List<DeliveryPersonRegister>> GetAllAsync();
        public Task<DeliveryPersonRegister> GetByCnh(double cnh);
        public Task CreateAsync(DeliveryPersonRegister people);
        public Task UpdateAsync(int cnh, DeliveryPersonRegister people);
        public Task RemoveAsync(int cnh);
    }
}
