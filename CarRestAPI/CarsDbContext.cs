using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace CarRestAPI
{
    public class CarsDbContext : DbContext
    {
        public CarsDbContext(DbContextOptions<CarsDbContext> options) : base(options)
        {
            
        }

        public DbSet<Car> Cars { get; set; }
    }
}
