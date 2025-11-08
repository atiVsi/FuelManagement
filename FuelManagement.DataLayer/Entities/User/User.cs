using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.DataLayer.Entities.User;

public class User : EntityBase
{
    [Display(Name = "نام کاربری")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    [MinLength(3, ErrorMessage = "{0} نمی تواند کمتر از {1} کاراکتر باشد .")]
    public string? UserName { get; private set; }

    [Display(Name = "نام ")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    [MinLength(3, ErrorMessage = "{0} نمی تواند کمتر از {1} کاراکتر باشد .")]
    public string? Firstname { get; private set; }


    [Display(Name = "نام خانوادگی")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    [MinLength(3, ErrorMessage = "{0} نمی تواند کمتر از {1} کاراکتر باشد .")]
    public string? LastName { get; private set; }

    [Display(Name = "کدملی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    [MinLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    public string NationalCodeField { get; private set; }

    [Display(Name = "شماره همراه")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(13, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    [MinLength(13, ErrorMessage = "{0} نمی تواند کمتر از {1} کاراکتر باشد .")]
    public string? MobilePhoneNumber { get; private set; }


    [Display(Name = "ایمیل")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    [MinLength(5, ErrorMessage = "{0} نمی تواند کمتر از {1} کاراکتر باشد .")]
    [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
    public string? Email { get; private set; }
    [Display(Name = "زمان تغییر")]
    public DateTime? EditTime { get; private set; }

    public User(long id, string userName, string? firstname, string? lastName, string nationalCodeField, string mobilePhoneNumber, string? email )
    {
        Id = id;
        UserName = userName;
        Firstname = firstname;
        LastName = lastName;
        NationalCodeField = nationalCodeField;
        MobilePhoneNumber = mobilePhoneNumber;
        Email = email;
              
    }
    public void Edit( string userName, string? firstname, string? lastName, string nationalCodeField,string mobilePhoneNumber, string? email,DateTime? EditTime, string userLog)
    {
    
        UserName = userName;
        Firstname = firstname;
        LastName = lastName;
        NationalCodeField = nationalCodeField;
 
        MobilePhoneNumber = mobilePhoneNumber;
        Email = email;
        EditTime = DateTime.Now;
        UserLog = userLog;

    }
    public void UpdateUserLog(string userLog)
    {
        EditTime = DateTime.Now;
        UserLog = userLog;
    }


    public void Remove(string userLog)
    {
        IsDelete = true;
        EditTime = DateTime.Now;
        UserLog = userLog;
    }
}

