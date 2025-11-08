using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.Proposal
{
    public class CreateProposalcall
    {

        [Display(Name = "عنوان فراخوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string TitleProposalCall { get;  set; }


        [Display(Name = "توضیحات فراخوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string DescriptionProposalCall { get;  set; }



        [Display(Name = "تاریخ شروع فراخوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string StartDate { get;  set; }

        [Display(Name = "تاریخ پایان فراخوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string EndDate { get;  set; }


        public DateTime StartDateGregorian { get; set; }
        public DateTime EndDateGregorian { get; set; }


        [Display(Name = "امکان شرکت شهروند")]
        public bool IsPublic { get;  set; }

        [Display(Name = "شناسه های سازمان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public List<long> OrganizationIds { get; set; } = new List<long>();

        [Display(Name = "ایجاد شده توسط")]
        public string? UserLog { get; set; }
    }
}
