using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Infrastructure;

public class ImageService
{
    public static string AddToFile( string base64, string fileextension)
    {
        try
        {
            // ساخت پوشه مقصد اگر وجود نداشت
            var rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "fuelrate");
            if (!Directory.Exists(rootPath))
                Directory.CreateDirectory(rootPath);

            // ساخت نام امن برای فایل
            string uniqueName = $"{Guid.NewGuid()}.{fileextension}";

            // مسیر کامل فایل روی سرور
            string filePath = Path.Combine(rootPath, uniqueName);

            // تبدیل base64 به بایت و ذخیره
            byte[] fileBytes = Convert.FromBase64String(base64);
            File.WriteAllBytes(filePath, fileBytes);

            // مسیر URL برای ذخیره در دیتابیس
            string urlPath = $"/uploads/fuelrate/{uniqueName}";

            return urlPath;
        }
        catch (Exception ex)
        {
            // اگر خطایی رخ داد می‌تونی لاگ بزنی
            return "";
        }
    }

}
