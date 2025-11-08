using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.Proposal;

public class ProposalCallViewModel
{

    public long Id { get; set; }

    [Display(Name = "عنوان فراخوان")]
    public string TitleProposalCall { get; set; }

    [Display(Name = "تاریخ ایجاد ")]
    public string CreateDate { get; set; }

    [Display(Name = "توسط کاربر")]
    public string? UserLog { get; set; }

    [Display(Name = "نام")]
    public string? Firstname { get; set; }

    [Display(Name = "نام خانوادگی")]
    public string? LastName { get; set; }

    [Display(Name = "فعال /غیرفعال")]
    public bool IsDelete { get; set; }

    [Display(Name = "تاریخ شروع فراخوان")]
    public string StartDate { get;  set; }

    [Display(Name = "تاریخ پایان فراخوان")]
    public string EndDate { get;  set; }


    [Display(Name = "امکان شرکت شهروند")]
    public bool IsPublic { get;  set; }

    [Display(Name = "نام سازمان و منطقه")]
    public string OrganizationTitle { get; set; }


    public string ProposalcallDescription { get; set; }
  
}
