using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.UserDto;
public class UserDetailViewModel
{
    public long UserId { get; set; }

    [Display(Name = "کد پرسنلی")]
    public string? PersonalCode { get; set; }

    [Display(Name = "نام کاربری")]
    public string UserName { get; set; }

    [Display(Name = "نام ")]
    public string? Firstname { get; set; }

    [Display(Name = "نام خانوادگی")]
    public string? LastName { get; set; }

    [Display(Name = "کد ملی")]
    public string NationalCodeField { get; set; }

    [Display(Name = "کد پستی")]

    public string? PostalCode { get; set; }

    [Display(Name = "شماره همراه")]
    public string MobilePhoneNumber { get; set; }

    [Display(Name = "ایمیل")]
    public string? Email { get; set; }

    [Display(Name = "آدرس")]
    public string? Address { get; set; }


    [Display(Name = "تاریخ تولد")]
    public string? BirthDate { get; set; }

    [Display(Name = "محل خدمت")]
    public string? ProvinceName { get; set; }

    [Display(Name = "نام پدر")]
    public string? FatherName { get; set; }

    [Display(Name = "بیمه تکمیلی دارد؟")]
    public bool IsHaveinsurance { get; set; }

    [Display(Name = "تصویر پروفایل کاربر")]
    public string UserAvatar { get; set; }

    [Display(Name = "پست سازمانی")]
    public string JobState_1 { get; set; }

    [Display(Name = "شماره حساب")]
    public string CreditNumber { get; set; }

    [Display(Name = "جنسیت")]
    public string Sex { get; set; }

    [Display(Name = "تاریخ شروع همکاری")]
    public string EmployeeDate { get; set; }

    [Display(Name = "وضعیت شغلی")]
    public string ContractName { get; set; }

    [Display(Name = "تصویر امضاء")]
    public string? ImageSignature { get; set; }

    [Display(Name = "توسط")]
    public string? UserLog { get; set; }

    [Display(Name = "زمان تغییر")]
    public DateTime EditTime { get; set; }

    [Display(Name = "فعال/غیر فعال")]
    public bool IsDelete { get; set; }

    //public List<DependentViewModel.ListDependentViewModel>? Dependents { get; set; }
}

