using System;
using System.ComponentModel.DataAnnotations;

namespace WaterPlant_Dotnet.Models
{
    public class PlantModel
    {
        [Key]
        public int Id { get; set; }
        public DateTimeOffset? RequiredDueAt { get; set; }
        public DateTimeOffset? WateringAgainDueAt { get; set; }
        public DateTimeOffset? RequireWaitDueAt { get; set; }
        public string Reminder6h { get; set; }
        public string Reminder30s { get; set; }
        public bool RequireWaitWatering => RequireWaitDueAt >= DateTime.UtcNow;
        public bool RequiredWater => RequiredDueAt <= DateTime.UtcNow;
        public bool WateringAgain => WateringAgainDueAt <= DateTime.UtcNow;
    }
}