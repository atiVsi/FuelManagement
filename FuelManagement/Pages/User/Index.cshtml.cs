using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FuelManagement.Core.Dtos.Pagination;
using FuelManagement.Core.Dtos.UserDto;
using FuelManagement.Core.Services.Interface;

namespace FuelManagement.UI.Pages.User
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }


        [BindProperty]
        //public List<UserViewModel> Users { get; set; }
        public PaginatedList<UserViewModel> Users { get; set; }


        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;


        [BindProperty(SupportsGet = true)]
        public string FullName { get; set; }

        public string? Msg { get; set; }


        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }


        public void OnGet(int? pageIndex, string? searchString,string? msg)
        {
            Msg = msg;
            // نگهداری عبارت جستجو
            SearchString = searchString ?? "";
            PageIndex = pageIndex ?? 1;
            //FullName = fullName;
            //Users = _userService.GetUsersVmPaged(SearchString, PageIndex, PageSize); 
            
        }



        //public void OnGet(string? msg = null)
        //{
        //    Msg = msg;
        //    Users = _userService.GetUsersVm(FullName);
        //}
        //public void OnPost(long id)
        //{
        //    Users = _userService.GetUsersVm(FullName);
        //}
    }
}
