using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.Proposal
{
    public class CreateRecommendedFiled
    {
        [Required(ErrorMessage = "لطفاً عنوان را وارد کنید.")]
        [MinLength(3, ErrorMessage = "حداقل ۳ کاراکتر وارد کنید.")]
        public string FiledTitle { get; set; }
        public string UserLog { get; set;}
    }
}
