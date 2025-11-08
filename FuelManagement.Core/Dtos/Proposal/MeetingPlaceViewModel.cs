using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.Proposal
{
    public class MeetingPlaceViewModel
    {
        [Display(Name = "شناسه مکان")]
        public long Id { get; set; }


        [Display(Name = "عنوان مکان")]
        public string Title { get; set; }


        [Display(Name = "فعال/غیرفعال")]
        public bool Isdelete { get; set; }
    }
}
