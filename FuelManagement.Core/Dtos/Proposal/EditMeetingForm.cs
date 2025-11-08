using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.Proposal
{
    public class EditMeetingForm : CreateMeetingViewModel
    {
        public long Id { get; set; }
        public string MeetingDateShamsi { get; set; } // نمایش شمسی

    }
}
