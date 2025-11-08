using System;
using System.ComponentModel.DataAnnotations;

namespace FuelManagement.DataLayer.Entities
{
    public class FuelRecord
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string? VehicleName { get; set; }

        [Range(0, 200)]
        public double Liters { get; set; }

        [DataType(DataType.Date)]
        public DateTime RefuelDate { get; set; }
    }
}
