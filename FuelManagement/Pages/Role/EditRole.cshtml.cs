using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FuelManagement.Core.Services.Interface;
using FuelManagement.DataLayer.Entities.Permission;

namespace FuelManagement.UI.Pages.Role
{
    //[Authorize]
    public class EditRoleModel : PageModel
    {
        private readonly IPermissionService _permissionService;


        public EditRoleModel( IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [BindProperty]
        public DataLayer.Entities.Permission.Role Role { get; set; }
        [BindProperty]
        public string RoleTitle { get; set; }

        public List<Permission> Permission { get; set; }

        public IActionResult OnGet(long id)
        {
            Role = _permissionService.GetRolPermission(id);
            if (Role == null)
            {
                return NotFound();
            }
            RoleTitle = Role.RoleTitle;
            Permission = _permissionService.GetAllPermissions();

            return Page();
        }

        //public IActionResult OnPost(long id, List<long> permissionIds)
        public IActionResult OnPost(long id, [Bind] string RoleTitle, List<long> permissionIds)
        {
            //if (!ModelState.IsValid)
            //{
                //Permission = _permissionService.GetAllPermissions();
                //return Page();
            

            _permissionService.UpdateRole(Role.Id, RoleTitle, User.Identity.Name);
            _permissionService.UpdatePermissionsRole(Role.Id, permissionIds);

            var notif = System.Net.WebUtility.UrlEncode($"نقش {RoleTitle} با شناسه {Role.Id} ویرایش شد");
            return Redirect($"/Role?msg= {notif}");

        }
    }
}
