using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FuelManagement.Core.Dtos.UserDto;
using FuelManagement.Core.Services.Interface;
using FuelManagement.DataLayer.Entities.Permission;
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
        //public List<Role> Roles { get; set; } = new();
        public List<global::FuelManagement.DataLayer.Entities.Permission.Role> Roles { get; set; } = new();




        public async Task<IActionResult> OnGetAsync(int? userId, string? msg)
        {
            Msg = msg;
            //ViewData["Roles"] = _permissionService.Get().Where(r => !r.IsDelete).ToList();
            Roles = _permissionService.Get();
            if (userId == null)
                return Page();

            user = _userService.GetRoleByUserId(userId.Value);
            if (user == null)
                return NotFound();

            NationalCode = user.NationalCodeField;

            // حالا که نقش‌ها برای کاربر بارگذاری شده‌اند، آن‌ها را به مدل ارسال می‌کنیم
            // فرض می‌کنیم که UserRoles به صورت لیستی از IDهای نقش‌ها است
            //user.UserRoles = user.UserRoles.Select(ur => ur.RoleId).ToList();
            return Page();
        }

        public IActionResult OnPost(List<long> SelectedRoles, bool bRedirect)
        {
            _permissionService.EditRolesUser(user.UserId, SelectedRoles, User.Identity.Name);
            var notif = WebUtility.UrlEncode($"نقش‌های شما به کاربر با موفقیت داده شد.");
            return Redirect($"/User?msg={notif}");
        }
    }
}
