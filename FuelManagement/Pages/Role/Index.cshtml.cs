using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FuelManagement.Core.Dtos.Pagination;
using FuelManagement.Core.Services.Interface;

namespace FuelManagement.UI.Pages.Role
{
    //[Authorize]
    public class IndexModel : PageModel
    {
        private IPermissionService _roleService;
        public IndexModel(IPermissionService roleService)
        { 
            _roleService = roleService;
        }


        public PaginatedList<DataLayer.Entities.Permission.Role> Roles { get; set; }
        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;


        [BindProperty(SupportsGet = true)]
        public string? Msg { get; set; }


        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        //public IActionResult OnGet(int id, string search = "", string? msg = null)
        //{
        //    Msg = msg;

        //    Roles = _roleService.GetRol(search);
        //    return Page();
        //}



        //public async Task<IActionResult> OnGetAsync(int id, string search = "", string? msg = null)

        //{
        //    Msg = msg;

            
        //    var query = _roleService.GetRol(search); // فرض بر این‌که IQueryable فراهم می‌کنه
        //    Roles = PaginatedList<DataLayer.Entities.Permission.Role>
        //               .Create(query, PageIndex, PageSize);

        //    return Page();
        //}

        public async Task<IActionResult> OnGetAsync(int? pageIndex, string? searchString, string? msg)
        {
            Msg = msg;
            SearchString = searchString ?? "";
            var query = _roleService.GetRol(SearchString);

          

            // صفحه‌بندی
            PageIndex = pageIndex ?? 1;
            Roles = PaginatedList<DataLayer.Entities.Permission.Role>
                        .Create(query, PageIndex, PageSize);

            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            var role = _roleService.Get(id);
            _roleService.DeleteRole(role, true); 
            var msg = $"نقش {role.RoleTitle} حذف شد";
            return RedirectToPage("Index", new { msg });
        }

        public IActionResult OnPost(int id, bool isDelete, string notif)
        {
            var role = _roleService.Get(id);
            _roleService.DeleteRole(role, isDelete);
            var msg = $"نقش {role.RoleTitle} {(isDelete ? "غیر فعال شد" : "فعال شد")} ; {(isDelete ? "bg-danger" : "bg-success")}";
            return RedirectToPagePermanent("Index", new { msg });

        }
    }
}
