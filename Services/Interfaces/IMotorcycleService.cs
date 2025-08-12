using registerAPI.Entity;

namespace registerAPI.Services.Interfaces
{
    public interface IMotorcycleService
    {
        public Task<List<MotorcycleRegister>> GetAsync();
        public Task<MotorcycleRegister> GetByLicense(string? bikeLicense);
        public Task CreateAsync(MotorcycleRegister bike);
        public Task UpdateAsync(string? bikeLicense, MotorcycleRegister bike);
        public Task RemoveAsync(string bikeLicense);
    }
}
