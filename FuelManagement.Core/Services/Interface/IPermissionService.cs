using FuelManagement.Core.Services.Interface;
using FuelManagement.DataLayer.Entities.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Services.Interface
{
    public interface IPermissionService : IRepository<long, Role>
    {
        #region Role
        Role GetRolPermission(long id);
        List<Role> GetRol(string search);
        long AddRole(Role role);
        void UpdateRole(Role role);
        void UpdateRole(long roleId, string roleName, string userName);
        void DeleteRole(Role role, bool isDelete);
        void AddRolesToUser(List<long> roleIds, long userId);
        void EditRolesUser(long userId, List<long> rolesId, string nationalCodeField);
        bool CheckRoles(long roleId, string nationalCodeField);
        bool CheckUserRoles(string nationalCodeField);
        #endregion

        #region Permission

        List<Permission> GetAllPermissions();
        void AddPermissionsToRole(long roleId, List<long> permission);
        void UpdatePermissionsRole(long roleId, List<long> permissions);
        bool CheckPermission(long permissionId, string nationalCodeField);

        #endregion
    }
}
