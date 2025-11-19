using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FuelManagement.Core.Dtos.FuelRate;
using FuelManagement.Core.Services;
using FuelManagement.Core.Services.Interface;
using System.IO;
namespace FuelManagement.UI.Pages.FuelRate
{
    //[Authorize]
    public class CreateFuelRateModel : PageModel
    {
        private readonly IFuelRateService _fuelRateService;
        private readonly IWebHostEnvironment _env;
        public CreateFuelRateModel(IFuelRateService FuelRateService, IWebHostEnvironment env)
        {
            _fuelRateService = FuelRateService;
            _env = env;
        }

        [BindProperty]
        public CreateFuelRateDto Createnew { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Msg { get; set; }


        public void OnGet()
        {
        }



        public IActionResult OnPost()
        {
            //Createnew.UserLog = User.Identity.Name ?? "Unknown";

            if (!ModelState.IsValid)
                return Page();

            // مسیر ذخیره‌سازی فایل
            //string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/fuelrate");
            string uploadPath = Path.Combine(_env.WebRootPath, "uploads/fuelrate");
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var savedFiles = new List<string>();

            if (Createnew.FuelRateImage != null && Createnew.FuelRateImage.Count > 0)
            {
                foreach (var file in Createnew.FuelRateImage)
                {
                    // فقط PDF و JPG
                    var ext = Path.GetExtension(file.FileName).ToLower();
                    if (ext != ".pdf" && ext != ".jpg" && ext != ".jpeg")
                    {
                        ModelState.AddModelError("", "فقط PDF یا JPG مجاز است");
                        return Page();
                    }

                    // نام یکتا
                    string fileName = Guid.NewGuid().ToString("N") + ext;
                    string filePath = Path.Combine(uploadPath, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    savedFiles.Add(fileName);
                }
            }

            // ذخیره نام فایل‌ها در DTO (اگر لازم داری داخل DB نگه داری)
            Createnew.ImageNames = string.Join(",", savedFiles);
            bool result = false;
            try
            {
                result = _fuelRateService.Add(Createnew);
            }
            catch (Exception ex)
            {
                // breakpoint بگذار اینجا تا ex را ببینی
                var err = ex.ToString();
                ModelState.AddModelError("", "خطا در سرویس: " + ex.Message);
                return Page();
            }
            //var result = _fuelRateService.Add(Createnew);
            //if (!result)
            //{
            //    ModelState.AddModelError("", "خطا در ذخیره‌سازی اطلاعات");
            //    return Page();
            //}

            return RedirectToPage("Index", new { msg = "با موفقیت ثبت شد" });
        }


    }
}
