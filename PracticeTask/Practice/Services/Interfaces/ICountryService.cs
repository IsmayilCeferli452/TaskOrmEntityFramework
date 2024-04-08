using Practice.Models;

namespace Practice.Services.Interfaces
{
    internal interface ICountryService
    {
        Task CreateAsync(Country country);
        Task DeleteAsync(int id);
        Task<List<Country>> GetAllAsync();
        Task<Country> GetByIdAsync(int id);
    }
}
