using CurrencyConverter.Models;
using Microsoft.EntityFrameworkCore;

namespace ConverterAPI.Data
{
    public class ConverterDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }

        public DbSet<Currency> Currencies { get; set; }
        
        public DbSet<CurrencyHistory> CurrencyHistories { get; set; }

        public ConverterDbContext(DbContextOptions<ConverterDbContext> options)
            : base(options) {}
    }
}
