using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.Proposal
{
    public class ProposalSearchModel
    {
        [Display(Name = "نام پیشنهاد دهنده")]
        public string? FirstName { get;  set; }

        [Display(Name = "نام خانوادگی پیشنهاد دهنده")]
        public string? LastName { get;  set; }

        [Display(Name = "کدملی پیشنهاد دهنده")]
        public string? Nationalcode { get;  set; }


        [Display(Name = "کدپرسنلی پیشنهاد دهنده")]
        public string? PersonelCode { get; set; }

        [Display(Name = "عنوان پیشنهاد")]
        public string? ProposalTitle { get;  set; }

        [Display(Name = "عنوان فراخوان")]
        public string? ProposalCallName { get;  set; }

        [Display(Name = "عنوان زمینه پیشنهادات")]
        public string? RecommendedFieldTitleName { get;  set; }


        public List<long>? ProposalCallIds { get; set; }   // چند انتخابی
        public List<long>? RecommendedFieldIds { get; set; } // چند انتخابی


        public int? ProposalId { get; set; }

        public string? UserQamyarId { get; set; }


        [Display(Name = "تاریخ از")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "تاریخ تا")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }


        public int? ProposalType { get; set; }

        public int? ProposalState { get; set; }
    }
}
