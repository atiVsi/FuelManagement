using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FuelManagement.Core.Dtos.UserDto;
using FuelManagement.Core.Services.Interface;
using System.Net;

namespace FuelManagement.UI.Pages.User
{
    public class EditUserModel : PageModel
    {

        private readonly IUserService _userService;
        private IPermissionService _permissionService;

        public EditUserModel(IUserService userService, IPermissionService permissionService)
        {
            _userService = userService;
            _permissionService = permissionService;
        }






        [BindProperty]
        public RoleToGiveUser user { get; set; }

        public string? Msg { get; set; }

        [BindProperty]
        public string NationalCode { get; set; }
 
        public async Task<IActionResult> OnGetAsync(int? userId,string? msg)
        {
            Msg = msg;
            ViewData["Roles"] = _permissionService.Get().Where(r => !r.IsDelete).ToList();

            if (userId == null)
                return Page();

            user = _userService.GetRoleByUserId(userId.Value);
            if (user == null)
                return NotFound();

            NationalCode = user.NationalCodeField;
            return Page();
        }

        public IActionResult OnPost(List<long> SelectedRoles, bool bRedirect)
        {

            _permissionService.EditRolesUser(user.UserId, SelectedRoles, User.Identity.Name);
            //var fullName = $"{user.Firstname} {user.LastName}";
            var notif = WebUtility.UrlEncode($"نقش های شما به کاربر  با موفقیت داده شد ");



            return Redirect($"/User?msg={notif}");

        }

    }
}
