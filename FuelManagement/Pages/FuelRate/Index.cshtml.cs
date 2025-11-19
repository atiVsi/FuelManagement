using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FuelManagement.Core.Dtos.FuelRate;
using FuelManagement.Core.Dtos.OrganizationDto;
using FuelManagement.Core.Dtos.Pagination;
using FuelManagement.Core.Services;
using FuelManagement.Core.Services.Interface;
using FuelManagement.DataLayer.Entities;
using FuelManagement.DataLayer.Entities.FuelRate;

namespace FuelManagement.UI.Pages.FuelRate
{
    //[Authorize]
    public class IndexModel : PageModel
    {
        private readonly IFuelRateService _FuelRateService;

        public IndexModel(IFuelRateService FuelRateService)
        {
            _FuelRateService = FuelRateService;
        }
        public PaginatedList<ListFuelRateDto> FuelRates { get; set; }


        [BindProperty]
        public EditFuelRateDto EditFuelRate { get; set; }

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


            var query = _FuelRateService.GetAll(SearchString);
            // صفحه‌بندی
            PageIndex = pageIndex ?? 1;
            FuelRates = PaginatedList<ListFuelRateDto>
                        .Create(query, PageIndex, PageSize);

            return Page();
        }


        public IActionResult OnPostDelete(long id)
        {
            var result = _FuelRateService.Remove(id, User.Identity?.Name ?? "Unknown");

            if (result)
            {
                Msg = "نرخ سوخت با موفقیت حذف شد.";
            }
            else
            {
                Msg = "خطا در  جذف نرخ سوخت!";
            }

            // ریدایرکت با پیام، صفحه و عبارت جستجو (برای حفظ وضعیت صفحه)
            return RedirectToPage(new { msg = Msg, pageIndex = PageIndex, searchString = SearchString });
        }






    }
}
