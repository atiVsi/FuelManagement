using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.Rewardrate
{
    public class CreateRewarDto
    {
        [Display(Name = "سال")]
        public string Year { get; set; }

        [Display(Name = "ضریب پاداش")]
        [Range(1, int.MaxValue, ErrorMessage = "ضریب باید بزرگتر از صفر باشد.")]
        public int RateNumber { get; set; }
        public string? UserLog { get; set; } = string.Empty;
    }
}
