using DefinitiveEdition.Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DefinitiveEdition.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Series> Series { get; set; }
        public DbSet<FeatureType> FeatureTypes { get; set; }
    }
}
