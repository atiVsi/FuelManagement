using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FuelManagement.Core.Dtos.UserDto;

public class UserSearchModel
{
    public string SearchName { get; set; }

    public Sorting Sorting { get; set; }
    public int PageId { get; set; }
    public int PageSize { get; set; }
    public int PageCount { get; set; }
    public int ListCount { get; set; }
    public List<SelectListItem> Sexs { get; set; }
    public int sex { get; set; }
    public List<SelectListItem> IsHaveInsurances { get; set; }
    public string IsHaveInsurance { get; set; }
}


public enum Sorting
{
    [Display(Name = "مرتب سازی صعودی شناسه")]
    AscId = 0,

    [Display(Name = "مرتب سازی نزولی شناسه")]

    DecId = 1,

    [Display(Name = "مرتب سازی صعودی نام ")]
    AscName = 2,

    [Display(Name = "مرتب سازی نزولی نام ")]

    DecName = 3,

    [Display(Name = "مرتب سازی صعودی نام خانوادگی")]
    AscLast = 4,

    [Display(Name = "مرتب سازی نزولی نام خانوادگی")]

    DecLast = 5,

    [Display(Name = "مرتب سازی صعودی کد ملی بیمار")]
    AscNationalCode = 6,

    [Display(Name = "مرتب سازی نزولی کد ملی بیمار")]

    DecNationalCode = 7,

    [Display(Name = "مرتب سازی صعودی کد پرسنلی سرپرست")]
    AscPersonalCode = 8,

    [Display(Name = "مرتب سازی نزولی کد پرسنلی سرپرست")]

    DecPersonalCode = 9,


    [Display(Name = "مرتب سازی صعودی جنسیت")]
    AscSex = 10,

    [Display(Name = "مرتب سازی نزولی جنسیت")]

    DecSex = 11,

    [Display(Name = "مرتب سازی صعودی مشمول بیمه")]
    AscIsHaveInsurance = 12,

    [Display(Name = "مرتب سازی نزولی مشمول بیمه")]

    DecIsHaveInsurance = 13,

    [Display(Name = "مرتب سازی صعودی وضعیت شغلی")]
    AscEmploymentStatus = 14,

    [Display(Name = "مرتب سازی نزولی وضعیت شغلی")]

    DecEmploymentStatus = 15,


    [Display(Name = "مرتب سازی صعودی تاریخ ثبت نام")]
    AscCreateDate = 16,

    [Display(Name = "مرتب سازی نزولی تاریخ ثبت نام")]

    DecCreateDate = 17,

}
