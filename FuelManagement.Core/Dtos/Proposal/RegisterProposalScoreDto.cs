using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.Proposal
{
    public class RegisterProposalScoreDto
    {
        public string CommentDescription {  get; set; } 
        public int ExpertOpinionSuggestion { get; set; }
        public long ProposalId { get; set;}
        public long UserId { get; set;}
        public DateTime Creationdate { get; set; }
        public DateTime EditTime { get; set; }
        public decimal Mark { get; set; }
        public string LastDescriptionStatus { get; set; }
        public long LastStatus { get; set; }
        public decimal AcceptedMark { get; set; }
        public string Nationalcode { get; set; }

        public long? RateId { get; set; }

    }
}
