//using FuelManagement.Core.Dtos.ReportDto;
//using FuelManagement.DataLayer.Entities.Proposal;
using FuelManagement.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Services.Interface
{
    public interface IUserReportService : IRepository<long,User>
    {
        //List<UserreportViewModel> GetUserReport(string? personelCode, int roleId);
    }
}
