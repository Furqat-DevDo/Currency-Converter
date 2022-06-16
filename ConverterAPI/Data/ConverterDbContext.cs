using CurrencyConverter.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ConverterAPI.Data
{
    public class ConverterDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public ConverterDbContext(DbContextOptions<ConverterDbContext> options)
            : base(options) {}

        public override int SaveChanges()
        {
            var changedEntities = ChangeTracker
                .Entries()
                .Where(_ => _.State == EntityState.Added ||
                            _.State == EntityState.Modified);

            var errors = new List<ValidationResult>(); 
            foreach (var e in changedEntities)
            {
                var vc = new ValidationContext(e.Entity, null, null);
                Validator.TryValidateObject(
                    e.Entity, vc, errors, validateAllProperties: true);
            }

            return base.SaveChanges();
        }
    }
}
