using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.DataLayer.Entities.Rules;
public class Rules : EntityBase
{
    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "عنوان را وارد کنید")]
    [StringLength(200, ErrorMessage = "عنوان نباید بیشتر از 200 کاراکتر باشد")]
    public string Title { get; private set; }

    [Display(Name = "توضیحات")]
    [Required(ErrorMessage = "عنوان را وارد کنید")]
    public string Description { get; private set; }

    [Display(Name = "تصویر خبر")]
    public string RuleImage { get; private set; }

    [Display(Name = "نوع فایل")]
    public string? FileType { get; private set; }



    public Rules() { }
    public Rules(string title, string description, string ruleImage, string Userlog, string fileType)
    {
        Title = title;
        Description = description;
        RuleImage = ruleImage;
        UserLog = Userlog;
        FileType = fileType;
    }
    public void Edit(string title, string description, string ruleImage, string Userlog, string fileType)
    {
        Title = title;
        Description = description;
        RuleImage = ruleImage;
        UserLog = Userlog;
        FileType = fileType;
    }
    public void Remove(string userLog)
    {
        UserLog = userLog;
        IsDelete = true;
    }
}
