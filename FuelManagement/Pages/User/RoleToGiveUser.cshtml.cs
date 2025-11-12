using FuelManagement.Core.Dtos.UserDto;
using FuelManagement.Core.Infrastructure;
using FuelManagement.Core.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace FuelManagement.UI.Pages.User
{
    public class RoleToGiveUserModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IPermissionService _permissionService;

        public RoleToGiveUserModel(IUserService userService, IPermissionService permissionService)
        {
            _userService = userService;
            _permissionService = permissionService;
        }

        [BindProperty]
        public RoleToGiveUser user { get; set; }

        public string? Msg { get; set; }

        [BindProperty]
        public string NationalCode { get; set; }

        public async Task OnGetAsync(string userName, string? msg)
        {
            Msg = msg;

            ViewData["Roles"] = _permissionService.Get()
                .Where(r => !r.IsDelete)
                .ToList();

            if (string.IsNullOrWhiteSpace(userName))
                return;

            var userEntity = _userService.GetUserByNationalCode(userName);
            if (userEntity != null)
            {
                user = _userService.GetRoleByUserId(userEntity.Id);
                NationalCode = user.NationalCodeField;
            }
        }

        public IActionResult OnPost(List<long> SelectedRoles)
        {
            if (user == null)
                return Page();

            // ساخت Profile از user
            Profile profile = new Profile
            {
                userNameField = user.UserName,
                firstNameField = user.Firstname,
                lastNameField = user.LastName,
                nationalCodeField = user.NationalCodeField,
                mobileNumberField = user.MobilePhoneNumber
            };

            // اضافه کردن کاربر
            var newUser = _userService.AddUser(profile);

            // اختصاص نقش‌ها
            _permissionService.EditRolesUser(newUser.Id, SelectedRoles, User.Identity.Name);

            var notif = WebUtility.UrlEncode($"کاربر {newUser.Firstname + " " + newUser.LastName} افزوده شد");
            return Redirect($"/User?msg={notif}");
        }
    }
}
