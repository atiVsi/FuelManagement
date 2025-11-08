using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.RoleVm;

public class CreateRole
{
    public string RoleTitle { get; set; }
    public string UserLog { get; set; }
    public List<int> Permissions { get; set; } = new List<int>(); // شناسه‌های دسترسی‌های انتخاب‌شده
}
