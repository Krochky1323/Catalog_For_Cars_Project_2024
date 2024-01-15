namespace Data
{
    using Catalog_For_Cars_Project_2024.Models;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    //AppDbContext е предназначен да бъде използван като контекст на база данни в приложение, тъй като наследява IdentityDbContext
    public class AppDbContext : IdentityDbContext
    {

        //Връзка на базата данни с моделите
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
