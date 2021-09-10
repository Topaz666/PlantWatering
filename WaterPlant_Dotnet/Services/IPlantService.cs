using System;
using System.Threading.Tasks;
using WaterPlant_Dotnet.Models;

namespace WaterPlant_Dotnet.Services
{
    public interface IPlantService
    {
        Task<PlantModel[]> GetCompletePlantsAsync();
        Task<bool> UpdatePlantsDueAsync(int id);
    }
}