using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.Proposal
{
    public class CreateMeetingViewModel
    {
        public long Id { get; set; } // شماره جلسه اتوماتیک
        public string Title { get; set; } // عنوان جلسه
        public long RecommendedId { get; set; } // کمیته
        [BindProperty]
        public string? MeetingDateShamsi { get; set; } // فقط برای نمایش شمسی
        public DateTime MeetingDate { get; set; } // ذخیره میلادی
        public string MeetingHour { get; set; } // ساعت جلسه
        public long MeetingPlaceId { get; set; } // مکان جلسه
        public int MeetingStatus { get; set; } // وضعیت جلسه
        public string MeetingDescription { get; set; } // دستور جلسه
        public IFormFile MeetingFile { get; set; } // فایل صورتجلسه
        public string? MeetingFilestr { get; set; } // مسیر فایل قبلی یا ذخیره جدید
        public string Userlog { get; set; } // کاربر جاری
    }
}
