using WaterPlant_Dotnet.Models;
using WaterPlant_Dotnet.Data;
using Microsoft.EntityFrameworkCore;
using Humanizer;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace WaterPlant_Dotnet.Services
{
    public class PlantService : IPlantService
    {
        private readonly ApplicationDbContext _context;
        public PlantService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PlantModel[]> GetCompletePlantsAsync()
        {
            var items = await _context.Plant
                        .ToArrayAsync();
            foreach(var item in items)
            {
                item.Reminder30s = item.WateringAgainDueAt.Humanize();
                item.Reminder6h = item.RequiredDueAt.Humanize();
            }     
            return items;
        }
        public async Task<bool> UpdatePlantsDueAsync(int id)
        {
            var item = await _context.Plant
                    .Where(x=>x.Id == id)
                    .SingleOrDefaultAsync();
            if (item == null) return false;
            item.RequiredDueAt = DateTimeOffset.Now.AddHours(6);
            item.WateringAgainDueAt = DateTimeOffset.Now.AddSeconds(30);
            item.RequireWaitDueAt = DateTimeOffset.Now.AddSeconds(10);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}