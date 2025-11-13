using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FuelManagement.Core.Dtos.RoleVm;
using FuelManagement.Core.Services.Interface;
using FuelManagement.DataLayer.Entities.Permission;
using System.Collections.Generic;

namespace FuelManagement.UI.Pages.Role
{
    public class CreateRoleModel : PageModel
    {
        private readonly IPermissionService _permissionService;

        public CreateRoleModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [BindProperty]
        public CreateRole Role { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Msg { get; set; }

        public List<Permission> Permission { get; set; }

        public void OnGet(string? msg)
        {
            Msg = msg;
            Permission = _permissionService.GetAllPermissions();
        }

        public IActionResult OnPost(List<long> permissionIds, bool bRedirect)
        {
            Role.UserLog = User.Identity?.Name ?? "System";

            var roleEntity = new DataLayer.Entities.Permission.Role(Role.RoleTitle, Role.UserLog, 0);
            var roleId = _permissionService.AddRole(roleEntity);

            if (permissionIds != null && permissionIds.Count > 0)
            {
                _permissionService.AddPermissionsToRole(roleId, permissionIds);
            }

            var notif = System.Net.WebUtility.UrlEncode($"نقش {Role.RoleTitle} افزوده شد");
            return Redirect($"/Role?msg={notif}");
        }
    }
}
