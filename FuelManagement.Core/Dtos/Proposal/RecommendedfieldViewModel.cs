using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.Proposal
{
    public class RecommendedfieldViewModel
    {
        public long Id { get; set; }

        [Display(Name = " عنوان ")]
        public string FieldTitle { get; private set; }


        [Display(Name = "تاریخ ایجاد ")]
        public string CreateDate { get; set; }

        [Display(Name = "توسط کاربر")]
        public string? UserLog { get; set; }

        [Display(Name = "فعال /غیرفعال")]
        public bool IsDelete { get; set; }
    }
}
