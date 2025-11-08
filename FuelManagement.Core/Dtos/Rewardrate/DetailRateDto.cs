using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.Rewardrate
{
    public class DetailRateDto
    {
        public long Id { get; set; }

        public string Year { get; set; }
        public int Ratenumber { get; set; }
        public string CreationDate { get; set; }
        public string UserLog { get; set; }
    }
}
