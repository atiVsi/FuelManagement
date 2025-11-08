using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.Rewardrate
{
    public class ListRateDto
    {
        public long Id { get; set; }
        public string year { get; set; }
        public bool IsDelete { get; set; }
        public string CreationDate { get; set; }
        public string UserLog { get; set; }
        public int ratenumber { get; set; }

    }
}
