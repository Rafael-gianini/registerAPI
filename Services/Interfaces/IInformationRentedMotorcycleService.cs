using registerAPI.Entity;

namespace registerAPI.Services.Interfaces
{
    public interface IInformationRentedMotorcycleService
    {
        public Task<List<InformationRentedMotorcycle>> GetAsync();
        public Task<InformationRentedMotorcycle> GetByLicense(string? bikeLicense);
        public Task CreateAsync(InformationRentedMotorcycle bike);
        public Task UpdateAsync(string bikeLicense, InformationRentedMotorcycle bike);
        public  Task RemoveAsync(string bikeLicense);

    }
}
