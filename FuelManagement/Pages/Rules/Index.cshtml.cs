using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FuelManagement.Core.Dtos.News;
using FuelManagement.Core.Dtos.Pagination;
using FuelManagement.Core.Dtos.Rules;
using FuelManagement.Core.Services;
using FuelManagement.Core.Services.Interface;


namespace FuelManagement.UI.Pages.Rules
{
    //[Authorize]
    public class IndexModel : PageModel
    {
        private readonly IRulesService _rulesService;

        public IndexModel(IRulesService rulesService)
        {
            _rulesService = rulesService;
        }


        public PaginatedList<ListRulesDto> Rules { get; set; }


        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        [BindProperty(SupportsGet = true)]
        public string? Msg { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }




        public async Task<IActionResult> OnGetAsync(int? pageIndex, string? searchString, string? msg)
        {
            // پیام نوتیفیکیشن
            Msg = msg;

            // نگهداری عبارت جستجو
            SearchString = searchString ?? "";


            var query = _rulesService.GetAll(SearchString);
            // صفحه‌بندی
            PageIndex = pageIndex ?? 1;
            Rules = PaginatedList<ListRulesDto>
                        .Create(query, PageIndex, PageSize);

            return Page();
        }
        public IActionResult OnPostDelete(long id)
        {
            var result = _rulesService.Remove(id, User.Identity?.Name ?? "Unknown");

            if (result)
            {
                Msg = "خبر با موفقیت حذف شد.";
            }
            else
            {
                Msg = "خطا در حذف خبر!";
            }

            // ریدایرکت با پیام، صفحه و عبارت جستجو (برای حفظ وضعیت صفحه)
            return RedirectToPage(new { msg = Msg, pageIndex = PageIndex, searchString = SearchString });
        }

       
    }
}
