using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.News
{
    public class CreateNewsDto
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "عنوان الزامی است")]
        public string Title { get;  set; }

        [Display(Name = "متن خبر")]
        public string NewsDescription { get;  set; }

        [Display(Name = "تصویر خبر")]
        public List<IFormFile> NewsImage { get;  set; }

        [Display(Name = "تاریخ انتشار")]
        public DateTime PublishDate { get;  set; } = DateTime.Now;

        public string?  PublishDatestr { get; set; }
        [Display(Name = "منتشر شده")]
        public bool IsPublished { get;  set; } = true;

        //[Required(ErrorMessage = "کاربر ثبت‌کننده الزامی است")]
        public string? UserLog { get; set; } = string.Empty;
    }
}
