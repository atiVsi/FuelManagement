using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.DataLayer.Entities.Permission;

public class RolePermission : EntityBase
{
    [Required]
    public long RoleId { get; private set; }

    [Required]
    public long PermissionId { get; private set; }

    #region Relations

    // هر نقشی دارای سطوح دسترسی است
    [ForeignKey("PermissionId")]
    public Permission Permission { get; private set; }

    [ForeignKey("RoleId")]
    public Role Role { get; private set; }

    #endregion


    // سازنده
    public RolePermission()
    {
    }

    // سازنده جدید که فقط RoleId و PermissionId را دریافت می‌کند
    public RolePermission(long roleId, long permissionId)
    {
        RoleId = roleId;
        PermissionId = permissionId;
    }

}
