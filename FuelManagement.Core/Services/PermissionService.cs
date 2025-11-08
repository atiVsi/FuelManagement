using FuelManagement.Core.Services.Interface;
using FuelManagement.DataLayer.Context;
using FuelManagement.DataLayer.Entities.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace FuelManagement.Core.Services
{
    public class PermissionService : RepositoryBase<long, Role>, IPermissionService
    {
        private readonly FuelmanagementContext _context;
        private readonly IUserService _userService;


        public PermissionService(FuelmanagementContext context, IUserService userService) : base(context)
        {
            _context = context;
            _userService = userService;
        }

        public Role GetRolPermission(long id)
        {
            return _context.Roles
                .Include(x => x.RolePermissions)
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.User)
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Role> GetRol(string search = "")
        {
            if (string.IsNullOrWhiteSpace(search))
                return _context.Roles.ToList();
            return _context.Roles
                .Where(x => x.RoleTitle.Contains(search))
                .ToList();
        }



        public long AddRole(Role role)
        {
            Create(role);
            SaveChanges();
            return role.Id;
        }

        public void UpdateRole(Role role)
        {
            var query = Get(role.Id);
            query.Edit(role.RoleTitle, role.UserLog);
            SaveChanges();
        }

        public void UpdateRole(long roleId, string roleName, string userName)
        {
            var role = Get(roleId);
            if (role == null) return;

            role.Edit(roleName, userName);
            _context.Roles.Update(role);
            SaveChanges();
        }

        public void DeleteRole(Role role, bool isDelete)
        {
            var query = Get(role.Id);
            query.Remove(isDelete, role.UserLog);
            SaveChanges();
        }

        public void AddRolesToUser(List<long> roleIds, long userId)
        {
            foreach (var userRole in from long roleId in roleIds select new UserRole(0, userId, roleId))
            {
                _context.UserRoles.Add(userRole);
            }

            SaveChanges();
        }

        // ویرایش نوع نقش های کاربر یا افزودن نقش جدید

        public void EditRolesUser(long userId, List<long> rolesId, string nationalCodeField)
        {
            //حذف تمام نقش های کاربر 
            _context.UserRoles.Where(r => r.UserId == userId).ToList()
                .ForEach(r => _context.UserRoles.Remove(r));
            SaveChanges();

            //دادن نقش جدید به کاربر
            AddRolesToUser(rolesId, userId);

            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                user.UpdateUserLog(nationalCodeField);
            }


            SaveChanges();
        }
        public bool CheckRoles(long roleId, string nationalCodeField)
        {
            long userid = _userService.GetUserByNationalCode(nationalCodeField).Id;

            return _context.UserRoles.Any(r => r.RoleId == roleId && r.UserId == userid);
        }

        public bool CheckUserRoles(string nationalCodeField)
        {
            long userid = _userService.GetUserByNationalCode(nationalCodeField).Id;

            return _context.UserRoles.Any(r => r.UserId == userid && r.RoleId == 1);
        }
        public List<Permission> GetAllPermissions()
        {
            return _context.Permissions.ToList();
        }
        public void AddPermissionsToRole(long roleId, List<long> permission)
        {
            foreach (var rolePermission in permission.Select(p => new RolePermission(0, roleId, p)))
            {
                _context.RolePermissions.Add(rolePermission);
            }
            SaveChanges();

        }
        public void UpdatePermissionsRole(long roleId, List<long> permissions)
        {
            _context.RolePermissions
                .Where(P => P.RoleId == roleId)
                .ToList()
                .ForEach(P => _context.RolePermissions.Remove(P));

            SaveChanges();
            AddPermissionsToRole(roleId, permissions);
        }
        public bool CheckPermission(long permissionId, string nationalCodeField)
        {
            var userid = _userService.GetUserByNationalCode("0371027233").Id;

            var userRoles = _context.UserRoles
                .Where(r => r.UserId == userid)
                .Select(r => r.RoleId)
                .ToList();

            if (!userRoles.Any())
                return false;

            List<long> rolesPermission = _context.RolePermissions
                .Where(r => r.PermissionId == permissionId)
                .Select(r => r.RoleId).
                ToList();

            return rolesPermission.Any(p => userRoles.Contains(p));
        }


    }
}
