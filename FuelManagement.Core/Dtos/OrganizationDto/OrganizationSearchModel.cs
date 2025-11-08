using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.OrganizationDto;

public class OrganizationSearchModel
{
    [Display(Name = "عنوان منطقه یا سازمان")]
    public string? Title { get; set; }
    [Display(Name = "تاریخ ایجاد")]
    public string CreateDate { get; set; }
    [Display(Name = "توسط")]
    public string UserLog { get; set; }
    [Display(Name = "نام")]
    public string? Firstname { get; set; }
    [Display(Name = "نام خانوادگی")]
    public string? LastName { get; set; }
}
