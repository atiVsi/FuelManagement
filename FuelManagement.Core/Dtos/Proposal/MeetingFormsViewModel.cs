using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.Proposal
{
    public class MeetingFormsViewModel
    {

        public long Id { get; set; }
        public long mmId { get; set; }

        public string Title { get; set; }
        public long RecommendedId { get; set; }
        public string RecommendedTitle { get; set; }
        public int Status { get; set; }
        public string StatusDescription { get; set; }
        public string MeetingDate { get; set; }
        
    }
}
