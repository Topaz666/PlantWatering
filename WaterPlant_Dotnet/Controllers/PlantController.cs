using Microsoft.AspNetCore.Mvc;
using WaterPlant_Dotnet.Services;
using System.Threading.Tasks;
using WaterPlant_Dotnet.Models;
using Microsoft.AspNetCore.Http;
using System;

namespace WaterPlant_Dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlantController:ControllerBase
    {
        private readonly IPlantService _plantService;
        public PlantController(IPlantService plantService)
        {
            _plantService = plantService;
        }
        [HttpPost("{id}/updateplant")]
        public async Task<IActionResult> UpdateDue(int id)
        {
            if(id == 0 ) return NotFound();
            var successful = await _plantService.UpdatePlantsDueAsync(id);
            if(!successful)
            {
                return BadRequest("Could Not Update Due");
            }
            return RedirectToAction("GetPlants");
        }

        [HttpGet("getplants")]
        public async Task<IActionResult> GetPlants()
        {
            var plants = await _plantService.GetCompletePlantsAsync();
            return Ok(plants);
        }

    }
}