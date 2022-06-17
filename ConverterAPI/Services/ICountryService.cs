using CurrencyConverter.Models;

namespace ConverterAPI.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetAll();
        Task<Country> GetById(string id);
        Task Create(Country entity);
        Task Update(Country entity);
        Task Delete(string id);
    }
}
