using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.DataLayer.Entities.Permission;
public class Permission : EntityBase
{
    [Display(Name = "عنوان نقش")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    public string PermissionTitle { get; private set; }


    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    public long? ParentId { get; private set; }


    #region Relations
    // هر دسترسی دارای یکسری نقش هاست
    public List<RolePermission> RolePermissions { get; private set; }

    [ForeignKey("ParentId")]
    public List<Permission> Permissions { get; private set; }


    #endregion



    // سازنده
    public Permission()
    {
    }


    public Permission(List<RolePermission> rolePermissions, List<Permission> permissions)
    {
        RolePermissions = rolePermissions;
        Permissions = permissions;
    }


    public Permission(string permissionTitle, long? parentId)
    {
        PermissionTitle = permissionTitle;
        ParentId = parentId;
        Id = 1;
    }


    public Permission(long id, string permissionTitle, long? parentId)
    {
        PermissionTitle = permissionTitle;
        ParentId = parentId;
        Id = id;
    }


}
