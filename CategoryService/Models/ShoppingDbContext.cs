using Microsoft.EntityFrameworkCore;

namespace CategoryService.Models
{
    public class CatShoppingDbContext : DbContext
    {
        public CatShoppingDbContext(DbContextOptions<CatShoppingDbContext> options):base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
