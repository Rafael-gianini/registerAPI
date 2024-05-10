using registerAPI.Entity;

namespace registerAPI.Services.Interfaces
{
    public interface IBikeService
    {
        public Task<List<BikeRegister>> GetAsync();
        public Task<BikeRegister> GetByLicense(string? bikeLicense);
        public Task CreateAsync(BikeRegister bike);
        public Task UpdateAsync(string bikeLicense, BikeRegister bike);
        public Task RemoveAsync(string bikeLicense);
    }
}
