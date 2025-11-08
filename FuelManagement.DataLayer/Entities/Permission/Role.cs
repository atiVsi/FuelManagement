using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.DataLayer.Entities.Permission;
// جدول لیست نقش ها 
public class Role : EntityBase
{
    [Display(Name = "عنوان نقش")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    public string RoleTitle { get; private set; } = string.Empty;



    #region Relations

    public List<UserRole> UserRoles { get; private set; }
    public List<RolePermission> RolePermissions { get; private set; }

    #endregion

    // سازنده
    public Role()
    {
        // هر کاربر لیستی از  نقش ها را میتواند داشنه باشد
        UserRoles = new List<UserRole>();
        RolePermissions = new List<RolePermission>();


    }

    // crud : تابع های مورد نیاز برای نقش ها
    public Role(string roleTitle, string? userLog, long id)
    {
        Id = id;
        RoleTitle = roleTitle;
        UserLog = userLog;
    }


    public void Edit(string roleTitle, string? userLog)
    {
        RoleTitle = roleTitle;
        UserLog = userLog;
    }


    public void Remove(bool isDelete, string? userLog)
    {
        IsDelete = isDelete;
        UserLog = userLog;
    }

}