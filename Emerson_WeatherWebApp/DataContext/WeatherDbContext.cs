using Emerson_WeatherApp.Entity;
using Microsoft.EntityFrameworkCore;
namespace Emerson_WeatherApp.DataContext
{
    public class WeatherDbContext : DbContext
    {
        public WeatherDbContext(DbContextOptions dbContextOptions):base (dbContextOptions)
        {
        }

        public DbSet<City> City { get; set; }
        public DbSet<Variable> Variable { get; set; }
    }
}
