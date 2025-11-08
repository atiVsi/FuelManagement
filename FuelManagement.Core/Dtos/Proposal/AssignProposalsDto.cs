using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.Proposal
{
    // برای ارسال پیشنهادات به صورت جلسه جهت بررسی 
    public class AssignProposalsDto
    {
        public List<long> ProposalIds { get; set; }
        public long MeetingId { get; set; }
    }
}
