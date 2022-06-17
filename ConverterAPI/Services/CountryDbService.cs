using ConverterAPI.Data;
using CurrencyConverter.Models;
using Microsoft.EntityFrameworkCore;

namespace ConverterAPI.Services
{
    public class CountryDbService : ICountryService
    {
        private readonly ConverterDbContext _context;
        public CountryDbService(ConverterDbContext context)
        {
            _context = context;
        }
    
        public Task Create(Country entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Countries.Add(entity);
            return _context.SaveChangesAsync();
        }

        public Task Delete(string id)
        {
            var entity = _context.Countries.FirstOrDefault(p => p.Id == id);
            if (entity == default)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Countries.Remove(entity);
            return _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            return await _context.Countries.ToListAsync();
        }

        public Task<Country> GetById(string id)
        {
            var entity = _context.Countries.FirstOrDefault(p => p.Id == id);
            if (entity == default)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            return Task.FromResult(entity);
        }

        public Task Update(Country entity)
        {
            var entityToUpdate = _context.Countries.FirstOrDefault(p => p.Id == entity.Id);
            if (entityToUpdate == default)
            {
                throw new ArgumentNullException(nameof(entityToUpdate));
            }
            entityToUpdate.Name = entity.Name;
            entityToUpdate.CurrencyName = entity.CurrencyName;
            entityToUpdate.Alpha3 = entity.Alpha3;
            entityToUpdate.CurrencySymbol = entity.CurrencySymbol;
            entityToUpdate.CurrencyId = entity.CurrencyId;
            return _context.SaveChangesAsync();
        }
       
    }
}
