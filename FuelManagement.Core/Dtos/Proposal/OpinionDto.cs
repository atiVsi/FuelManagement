using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.Proposal
{
    public class OpinionDto
    {
        public int Id { get; set; }
        public string Creationdate { get; set; }
        public string Editdate { get; set; }
        public double? Mark { get; set; }
        public double? acceptedMark { get; set; }
        public long UserId { get; set;}
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string? Userlog { get; set; } 
        public string? commentdescription { get; set; }
        public int expertsuggestion { get; set; }
        public string expertsuggestionname { get; set; }
        public string year { get; set; }
        public int ratenumber { get; set; }
        public long? RateId { get; set; }


    }
}
