using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.DataLayer.Entities.Permission;

// جدول نقش و کاربران
public class UserRole : EntityBase
{
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public long UserId { get; private set; }

    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public long RoleId { get; private set; }



    #region Relations

    // هر کاربر نقشی دارد
    [ForeignKey("UserId")]
    public User.User User { get; private set; }

    // هر کاربر چه نقش هایی دارد
    [ForeignKey("RoleId")]
    public Role Role { get; private set; }
    #endregion


    // سازنده
    public UserRole()
    {
    }

    public UserRole(long id, long userId, long roleId)
    {
        UserId = userId;
        RoleId = roleId;
        Id = id;
    }

}
