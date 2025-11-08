using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.Proposal
{
    public class ReportViewModel
    {
        [Display(Name = "شناسه پیشنهاد")]
        public long Id { get; set; }

        [Display(Name = "عنوان پیشنهاد")]
        public string ProposalTitle { get; set; }

        [Display(Name = "شناسه فراخوان")]
        public long ProposalCallId { get; set; }

        [Display(Name = "عنوان فراخوان")]
        public string ProposalCallName { get; set; }

        [Display(Name = "شناسه زمینه پیشنهادات")]
        public long RecommendedFieldTitleId { get; set; }

        [Display(Name = "عنوان زمینه پیشنهادات")]
        public string RecommendedFieldTitleName { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public string Creationdate { get; set; }


        [Display(Name = "کد ملی ثبت کننده")]
        public string NationalCode { get; set; }


        [Display(Name = "کد پرسنلی ثبت کننده")]
        public string? PersonelCode { get; set; }

        [Display(Name = "وضعیت پیشهاد")]
        public int ProposalState { get; set; }
        public string ProposalStatename { get; set; }

        [Display(Name = "امتیاز کسب شده")]
        public double? Mark { get; set; }

        [Display(Name = "امتیاز اصلی")]
        public int Ratereward { get; set; }

        [Display(Name = "امتیاز اصلی")]
        public double mainMark { get; set; }

        public long UserId { get; set; }

        public bool Attachment { get; set; }

        [Display(Name = "شناسه نوع")]
        public int Typeproposalid { get; set; }

        [Display(Name = "عنوان نوع")]
        public string Typeproposalname { get; set; }

        [Display(Name = "شناسه صورتجلسه")]
        public long? mId { get; set; }
    }
}
