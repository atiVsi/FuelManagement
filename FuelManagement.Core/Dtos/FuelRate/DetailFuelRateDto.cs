using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.FuelRate;

public class DetailFuelRateDto
{
    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "عنوان الزامی است")]
    public string FuelType { get; set; }

    [Display(Name = "مبلع")]
    [Required(ErrorMessage = "مبلغ الزامی است")]
    public string? Amount { get; set; }

    [Display(Name = "فایل پیوست")]
    public List<string> FuelRateImage { get; set; }

    [Display(Name = "تاریخ ویرایش")]
    public DateTime UpdateDate { get; set; } = DateTime.Now;
    public DateTime PublishDate { get; set; }
    public string PublishDateJalali { get; set; } = string.Empty; // برای فرم و ویرایش
    public string UpdateDateJalali { get; set; } = string.Empty;
    public string UserLog { get; set; } = string.Empty;


    public bool IsDelete { get; set; } = false;

}