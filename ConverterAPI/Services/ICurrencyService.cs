using CurrencyConverter.Models;

namespace ConverterAPI.Services
{
    public interface ICurrencyService
    {
        Task<IEnumerable<Currency>> GetAll();
        Task<Currency> GetById(string id);
        Task Create(Currency entity);
        Task Update(Currency entity);
        Task Delete(string id);
    }
}
