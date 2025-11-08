using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.Proposal
{
    public class ProposalcallSearchModel
    {
        [Display(Name = "عنوان فراخوان")]
        public string TitleProposalCall { get; set; }


        [Display(Name = "تاریخ شروع فراخوان")]
        public string StartDate { get;  set; }

        [Display(Name = "تاریخ پایان فراخوان")]
        public string EndDate { get;  set; }


        [Display(Name = "امکان شرکت شهروند")]
        public bool? IsPublic { get;  set; }

        [Display(Name = "نام سازمان و منطقه")]
        public string? OrganizationTitle { get; set; }

        public List<long> OrganizationIds { get; set; } = new();
    }
}
