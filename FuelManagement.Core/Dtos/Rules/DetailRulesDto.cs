using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.Rules
{
    public class DetailRulesDto
    {

        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "تصویر آیین نامه")]
        public List<string> RuleImage { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public string Creationdate { get; set; }

        [Display(Name = "ایجاد شده توسط")]
        public string Userlog { get; set; }

        [Display(Name = "حذف شده ")]
        public bool IsDelete { get; set; }
    }
}
