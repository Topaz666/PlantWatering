using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WaterPlant_Dotnet.Data;
using WaterPlant_Dotnet.Models;
using Microsoft.EntityFrameworkCore;
using WaterPlant_Dotnet.Services;
using System.Linq;
using System;


namespace WaterPlant_Dotnet
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IPlantService, PlantService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context)
        {
            createTestPlants(context);
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void createTestPlants(ApplicationDbContext context)
        {
            while(context.Plant.Count() < 5){
                var testPlant = new PlantModel{
                    RequiredDueAt = DateTimeOffset.Now.AddHours(6),
                    WateringAgainDueAt = DateTimeOffset.Now.AddSeconds(30),
                    RequireWaitDueAt = DateTimeOffset.Now.AddSeconds(10),
                };
                context.Plant.Add(testPlant);
                context.SaveChanges();
            }
        }
    }
}
