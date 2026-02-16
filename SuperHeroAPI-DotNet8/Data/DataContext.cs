using Microsoft.EntityFrameworkCore;
using SuperHeroAPI_DotNet8.Entities;

namespace SuperHeroAPI_DotNet8.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
