using registerAPI.Entity;

namespace registerAPI.Services.Interfaces
{
    public interface IRentedService
    {
        public  Task<List<RentedMotorcycle>> GetAsync();
        public Task<RentedMotorcycle> GetByLicense(string? bikeLicense);
        public Task CreateAsync(RentedMotorcycle bike);
        public Task UpdateAsync(string bikeLicense, RentedMotorcycle bike);
        public  Task RemoveAsync(string bikeLicense);
    }
}
