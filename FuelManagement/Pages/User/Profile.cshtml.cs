using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FuelManagement.Core.Dtos.UserDto;
using FuelManagement.Core.Services.Interface;

namespace FuelManagement.UI.Pages.User
{
    public class ProfileModel : PageModel
    {

        private readonly IUserService _userService;
        public ProfileModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public UserDetailViewModel DetailUSer { get; set; }

        public string Msg = "";


        //public IActionResult OnGet(int? id, string msg)
        //{
        //    Msg = msg;

        //    if (id.HasValue)
        //    {
        //        DetailUSer = _userService.GetUserProfileBy(id.Value); 
        //    }
        //    else if (User.Identity != null && User.Identity.IsAuthenticated)
        //    {
        //        DetailUSer = _userService.GetUserProfileBy(User.Identity.Name); 
        //    }


        //    if (DetailUSer == null)
        //    {
        //        return NotFound();
        //    }

        //    return Page();
           
        //}

        public IActionResult OnGet(int? id, string msg)
        {
            Msg = msg;
            if (id.HasValue)
            {
                //DetailUSer = _userService.GetUserProfileById(id.Value);

            }
            else
            {
                Msg += " | شناسه کاربر نامعتبر است یا کاربر لاگین‌نشده.";
                DetailUSer = null;
            }

            if (DetailUSer == null)
            {
                Msg += " | کاربر پیدا نشد.";
            }
            return Page();

        }
    }
}
