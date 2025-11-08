using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.OrganizationDto;

public class CreateOrganization
{
    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
    public string Title { get;  set; }
    [Display(Name = "تاریخ ایجاد")]
    public string? CreateDate { get; set; }
    [Display(Name = "ایجاد شده توسط")]
    public string? UserLog { get; set; }
    [Display(Name = "نام")]
    public string? Firstname { get; set; }
    [Display(Name = "نام خانوادگی")]
    public string? LastName { get; set; }
}
