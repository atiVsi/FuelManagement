using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.UserDto;

public class RoleToGiveUser
{
    public long UserId { get; set; }


    [Display(Name = "نام کاربری")]
    public string UserName { get; set; }

    [Display(Name = "نام ")]
    public string? Firstname { get; set; }

    [Display(Name = "نام خانوادگی")]
    public string? LastName { get; set; }

    [Display(Name = "کد ملی")]
    public string NationalCodeField { get; set; }

    [Display(Name = "کد پرسنلی")]
    public string? PersonalCode { get; set; }
    public List<long>? UserRoles { get; set; }
    //public List<long>? OrganizationsAgent { get; set; }

    public List<string>? UserRolesTitle { get; set; }

    [Display(Name = "شماره موبایل")]
    public string? MobilePhoneNumber { get; set; }

    [Display(Name = "تصویر امضاء")]
    public string? ImageSignature { get; set; }

    //User
    //کد ملی کاربری که آخرین تغییر را انجام داده
    [Display(Name = "توسط")]
    public string? UserLog { get; set; }

    [Display(Name = "زمان تغییر")]
    public DateTime EditTime { get; set; }

    [Display(Name = "فعال/غیر فعال")]
    public bool IsDelete { get; set; }

    //public List<DependentViewModel.ListDependentViewModel>? Dependents { get; set; }

}
