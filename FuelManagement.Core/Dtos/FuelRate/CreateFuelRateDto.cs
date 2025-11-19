using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.FuelRate
{
    public class CreateFuelRateDto
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "عنوان الزامی است")]
        public string FuelType { get; set; }

        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "مبلغ الزامی است")]
        public string? Amount { get; set; }

        [Display(Name = "فایل پیوست")]
        public List<IFormFile> FuelRateImage { get; set; } = new List<IFormFile>();
        public string? ImageNames { get; set; }

        public DateTime PublishDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public string PublishDateJalali { get; set; } = string.Empty;
        public string UpdateDateJalali { get; set; } = string.Empty;
        public string? UserLog { get; set; } = string.Empty;
    }
}

