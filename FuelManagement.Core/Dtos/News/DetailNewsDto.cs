using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.News;

public class DetailNewsDto
{
    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "عنوان الزامی است")]
    public string Title { get; set; }

    [Display(Name = "متن خبر")]
    public string NewsDescription { get; set; }

    [Display(Name = "تصویر خبر")]
    public List<string> NewsImage { get; set; }

    [Display(Name = "تاریخ انتشار")]
    public string PublishDate { get; set; }
    public DateTime PublishDateMiladi { get; set; } // برای فرم و ویرایش

    [Display(Name = "منتشر شده")]
    public bool IsPublished { get;  set; } = true;
    [Display(Name = "حذف شده شده")]
    public bool IsDelete { get; set; } 
    public string Userlog { get; set; }

}
