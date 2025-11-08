using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FuelManagement.Core.Dtos.ReportDto
{
    public class UserreportViewModel
    {
        
        // اطلاعات پیشنهاد

        // شناسه پیشنهاد
        public long ProposalId { get; set; }
        // عنوان پیشنهاد
        public string Proposalname { get; set; }

        
        // اطلاعات خود کاربری که گزارش عملکردش رو میخوایم 
        public long Userid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Nationalcode { get; set; }
        public string Personelcode { get; set; }

        // گزاراش پیشنهاد

        // زمان ایجاد پیشنهاد
        public string  ProposalCreationdate { get; set; }
        // زمان خروج پیشنهاد
        public string  ProposalExitdate { get; set; }

        // زمان دریافت پیشنهاد
        public string ProposalGetdate { get; set; }
        // مدت زمان باقی مانده پیشنهاد در کارتابل
        public long? ProposalDays { get; set; }    
        // وضعیت پیشنهاد
        public string ProposalStatus { get; set;}
        public int ProposalintStatus { get; set; }




    }
}
