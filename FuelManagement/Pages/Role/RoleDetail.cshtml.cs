using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FuelManagement.Core.Services.Interface;

namespace FuelManagement.UI.Pages.Role
{
    //[Authorize]
    public class RoleDetailModel : PageModel
    {
        private IPermissionService _permissionService;

        public RoleDetailModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }
        public DataLayer.Entities.Permission.Role Role { get; set; }

        public IActionResult OnGet(long id)
        {
            Role = _permissionService.GetRolPermission(id);
            return Page();
        }
    }
}
