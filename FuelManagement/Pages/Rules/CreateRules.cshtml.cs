using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FuelManagement.Core.Dtos.News;
using FuelManagement.Core.Dtos.Rules;
using FuelManagement.Core.Services;
using FuelManagement.Core.Services.Interface;

namespace FuelManagement.UI.Pages.Rules
{
    //[Authorize]
    public class CreateRulesModel : PageModel
    {
        private readonly IRulesService _rulesService;


        public CreateRulesModel(IRulesService rulesService)
        {
            _rulesService = rulesService;
        }

        [BindProperty]
        public CreateNewRule CreateRule { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Msg { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            CreateRule.Userlog = User.Identity.Name ?? "  ";

            if (!ModelState.IsValid)
            {
                return Page();
            }
            var result = _rulesService.Add(CreateRule);
            if (!result)
            {
                ModelState.AddModelError("", "خطا در ذخیره‌سازی اطلاعات");
                return Page();
            }
            return RedirectToPage("Index", new { msg = "آیین نامه با موفقیت افزوده شد" });


        }
    }
}
