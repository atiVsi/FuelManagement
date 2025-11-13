using System.Collections.Generic;

namespace FuelManagement.Core.Dtos.RoleVm
{
    public class CreateRole
    {
        public string RoleTitle { get; set; }
        public string UserLog { get; set; }
        public List<long> Permissions { get; set; } = new List<long>();
    }
}
