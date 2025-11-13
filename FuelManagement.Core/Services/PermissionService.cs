using FuelManagement.Core.Services.Interface;
using FuelManagement.DataLayer.Context;
using FuelManagement.DataLayer.Entities.Permission;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FuelManagement.Core.Services
{
    public class PermissionService : RepositoryBase<long, Role>, IPermissionService
    {
        private readonly FuelmanagementContext _context;

        public PermissionService(FuelmanagementContext context) : base(context)
        {
            _context = context;
        }

        #region Role
        public void EditRolesUser(long userId, List<long> rolesId, string nationalCodeField)
        {
            var userRoles = _context.UserRoles.Where(u => u.UserId == userId).ToList();
            _context.UserRoles.RemoveRange(userRoles);
            AddRolesToUser(rolesId, userId);
        }

        public void AddRolesToUser(List<long> roleIds, long userId)
        {
            foreach (var roleId in roleIds)
            {
                var userRole = new UserRole(0, userId, roleId);
                _context.UserRoles.Add(userRole);
            }
            _context.SaveChanges();
        }

        public List<Role> Get()
        {
            return _context.Roles.Where(r => !r.IsDelete).ToList();
        }
        public Role GetRolPermission(long id)
        {
            return _context.Roles.Include(r => r.RolePermissions).ThenInclude(rp => rp.Permission)
                                 .FirstOrDefault(r => r.Id == id);
        }
        public bool CheckPermission(long permissionId, string nationalCodeField)
        {
            // پیاده‌سازی متد: اینجا می‌توانید منطق چک کردن مجوزها را اضافه کنید.
            // به عنوان مثال، می‌توانید بررسی کنید که آیا مجوزی با id مشخص در پایگاه داده وجود دارد یا خیر.

            var permission = _context.Permissions.FirstOrDefault(p => p.Id == permissionId && p.NationalCodeField == nationalCodeField);

            return permission != null;
        }
        public void UpdatePermissionsRole(long roleId, List<long> permissions)
        {
            // ابتدا نقش مورد نظر را پیدا می‌کنیم
            var role = _context.Roles.Include(r => r.RolePermissions).FirstOrDefault(r => r.Id == roleId);

            if (role == null)
            {
                throw new Exception("Role not found");
            }

            // حذف تمام RolePermissionهای موجود
            _context.RolePermissions.RemoveRange(role.RolePermissions);

            // اضافه کردن مجوزهای جدید
            foreach (var permissionId in permissions)
            {
                var rolePermission = new RolePermission(roleId, permissionId); // استفاده از سازنده جدید
                _context.RolePermissions.Add(rolePermission);
            }

            // ذخیره تغییرات در پایگاه داده
            _context.SaveChanges();
        }
        public void AddPermissionsToRole(long roleId, List<long> permissionIds)
        {
            // ابتدا نقش را پیدا می‌کنیم
            var role = _context.Roles.Include(r => r.RolePermissions).FirstOrDefault(r => r.Id == roleId);

            if (role == null)
            {
                throw new Exception("Role not found");
            }

            // برای هر permissionId، یک RolePermission جدید می‌سازیم
            foreach (var permissionId in permissionIds)
            {
                // اگر permissionId موجود نباشد، باید آن را اضافه کنیم
                var permission = _context.Permissions.FirstOrDefault(p => p.Id == permissionId);

                if (permission == null)
                {
                    throw new Exception($"Permission with ID {permissionId} not found");
                }

                // حالا می‌توانیم یک شیء جدید از RolePermission بسازیم
                var rolePermission = new RolePermission(roleId, permissionId);

                // RolePermission جدید را به پایگاه داده اضافه می‌کنیم
                _context.RolePermissions.Add(rolePermission);
            }

            // ذخیره تغییرات
            _context.SaveChanges();
        }
        public List<Permission> GetAllPermissions()
        {
            // تمام مجوزها را از پایگاه داده دریافت می‌کنیم
            return _context.Permissions.Where(p => !p.IsDelete).ToList();
        }
        public bool CheckUserRoles(string nationalCodeField)
        {
            // بررسی اینکه آیا کاربر با کد ملی خاصی نقش دارد
            var userRoles = _context.UserRoles
                                    .Where(ur => ur.User.NationalCodeField == nationalCodeField)
                                    .ToList();

            return userRoles.Any(); // اگر حداقل یک نقش برای کاربر وجود داشته باشد، true برمی‌گرداند
        }

        public bool CheckRoles(long roleId, string nationalCodeField)
        {
            // بررسی اینکه آیا کاربر با کد ملی مشخص شده، دارای نقش مورد نظر است یا خیر
            var userRole = _context.UserRoles
                                   .Where(ur => ur.User.NationalCodeField == nationalCodeField && ur.RoleId == roleId)
                                   .FirstOrDefault();

            return userRole != null; // اگر کاربر دارای این نقش باشد، true برمی‌گرداند
        }
        public void UpdateRole(long roleId, string roleName, string userName)
        {
            // ابتدا نقش مورد نظر را با استفاده از roleId پیدا می‌کنیم
            var role = _context.Roles.FirstOrDefault(r => r.Id == roleId);

            if (role == null)
            {
                throw new Exception("Role not found");
            }

            // حالا نام نقش را به‌روزرسانی می‌کنیم
            role.RoleTitle = roleName;

            // می‌توانیم برای به‌روزرسانی اطلاعات دیگر (مثل "userName") نیز اقدام کنیم
            // در صورت نیاز می‌توانید به‌روزرسانی‌های اضافی انجام دهید

            // اطلاعات را ذخیره می‌کنیم
            _context.SaveChanges();
        }

        public void DeleteRole(Role role, bool isDelete)
        {
            var existingRole = _context.Roles.FirstOrDefault(r => r.Id == role.Id);

            if (existingRole == null)
            {
                throw new Exception("Role not found");
            }

            // اگر isDelete برابر با true باشد، نقش حذف می‌شود
            // در غیر این صورت، می‌توان نقش را به وضعیت غیر فعال (غیرفعال کردن) تغییر داد
            existingRole.IsDelete = isDelete;

            // اطلاعات را ذخیره می‌کنیم
            _context.SaveChanges();
        }
        public void UpdateRole(Role role)
        {
            var existingRole = _context.Roles.FirstOrDefault(r => r.Id == role.Id);

            if (existingRole == null)
            {
                throw new Exception("Role not found");
            }

            // به‌روزرسانی پروپرتی‌های نقش موجود
            existingRole.RoleTitle = role.RoleTitle;

            // اطلاعات را ذخیره می‌کنیم
            _context.SaveChanges();
        }
        public long AddRole(Role role)
        {
            // اضافه کردن نقش جدید به پایگاه داده
            _context.Roles.Add(role);

            // ذخیره تغییرات در پایگاه داده
            _context.SaveChanges();

            // بازگرداندن شناسه (ID) نقش جدید
            return role.Id;
        }
        public List<Role> GetRol(string search)
        {
            // اگر رشته جستجو خالی باشد، تمام نقش‌ها را برمی‌گردانیم
            if (string.IsNullOrEmpty(search))
            {
                return _context.Roles.Where(r => !r.IsDelete).ToList();
            }

            // اگر رشته جستجو وجود دارد، نقش‌هایی را که مطابق با جستجو هستند برمی‌گردانیم
            return _context.Roles
                           .Where(r => r.RoleTitle.Contains(search) && !r.IsDelete)
                           .ToList();
        }

        #endregion
    }
}
