using Microsoft.EntityFrameworkCore;
using WaterPlant_Dotnet.Models;

namespace WaterPlant_Dotnet.Data
{
    public class ApplicationDbContext  : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PlantModel> Plant {get; set;}   
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // ...
        }
    }
}