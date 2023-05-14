using Microsoft.EntityFrameworkCore;

namespace EcommerceCRUDAPI.Models
{
    public class BrandContext : DbContext
    {
        public BrandContext(DbContextOptions<BrandContext> options) : base(options)
        {

        }

        public DbSet<Brands> Brands{ get; set; }
    }
}
