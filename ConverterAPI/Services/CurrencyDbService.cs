using ConverterAPI.Data;
using CurrencyConverter.Models;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;

namespace ConverterAPI.Services
{
    public class CurrencyDbService:IGenericService<Currency>
    {
        private readonly ConverterDbContext _context;

        public CurrencyDbService(ConverterDbContext dbcontext)
        {
            _context = dbcontext;
        }

        public Task Create(Currency entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Currencies.Add(entity);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Delete(string id)
        {
            var entity = _context.Currencies.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Currencies.Remove(entity);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Currency>> GetAll()
        {
            return await  _context.Currencies.ToListAsync();
        }

        public Task<Currency> GetById(string id)
        {
            var entity = _context.Currencies.FirstOrDefault(x => x.Id == id);
            if (entity == null || entity.Id != id)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            return Task.FromResult(entity);
        }

        public Task Update(Currency entity)
        {
            var entityToUpdate = _context.Currencies.FirstOrDefault(x => x.Id == entity.Id);
            if (entityToUpdate == null)
            {
                throw new ArgumentNullException(nameof(entityToUpdate));
            }
            entityToUpdate.CurrencyName = entity.CurrencyName;
            entityToUpdate.CurrencySymbol = entity.CurrencySymbol;
            
            return Task.CompletedTask;
        }
    }
}
