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
        public PaginatedList<UserViewModel> Users { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public string? Msg { get; set; }

        public void OnGet(int? pageIndex, string? searchString, string? msg)
        {
            Msg = msg;
            
            SearchString = searchString ?? "";
            PageIndex = pageIndex ?? 1;
            string query = string.IsNullOrWhiteSpace(SearchString) ? "" : SearchString;
            Users = _userService.GetUsersVmPaged(query, PageIndex, 10)
                    ?? new PaginatedList<UserViewModel>(new List<UserViewModel>(), 0, PageIndex, 10);

        }
    }
}
