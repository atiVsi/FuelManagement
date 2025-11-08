using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FuelManagement.Core.Dtos.UserDto;
using FuelManagement.Core.Services.Interface;
using System.Net;

namespace FuelManagement.UI.Pages.User
{
    public class RoleToGiveUserModel : PageModel
    {

        private readonly IUserService _userService;
        private IPermissionService _permissionService;

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



        public async Task OnGetAsync(string userName,string? msg)
        {
            Msg = msg;
            ViewData["Roles"] = _permissionService.Get().Where(r => !r.IsDelete)
    .ToList(); ;


            if(string.IsNullOrWhiteSpace(userName))
            {
                return;
            }

            // اول بررسی کن کاربر توی دیتا بیس خودمون هست یا نه
            var userId = _userService.GetUserByNationalCode(userName);
            if(userId != null)
            {
                user = _userService.GetRoleByUserId(userId.Id);
                NationalCode = user.NationalCodeField;
            }
            else
            {
                // برو اطلاعات کاربر رو از سرویس بگیر
                //var personalUser = _userService.GetUserByNationalCodeInCast(userName);
                //if(personalUser != null)
                //{
                //    user = _userService.GetRoleByUserId(personalUser.Id);
                //    NationalCode = user.NationalCodeField;
                //}
            }
        }




        public IActionResult OnPost(List<long> SelectedRoles, bool bRedirect)
        {
            
                _permissionService.EditRolesUser(user.UserId, SelectedRoles, User.Identity.Name);
                //var fullName = $"{user.Firstname} {user.LastName}";
                var notif = WebUtility.UrlEncode($"کاربر { user.Firstname + " " + user.LastName} افزوده شد");



                return Redirect($"/User?msg={notif}");
           
        }
    }
}
