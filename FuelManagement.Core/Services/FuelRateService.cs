using Microsoft.AspNetCore.Http;
using FuelManagement.Core.Convertors;
using FuelManagement.Core.Dtos.FuelRate;
using FuelManagement.Core.Infrastructure;
using FuelManagement.Core.Services.Interface;
using FuelManagement.DataLayer.Context;
using FuelManagement.DataLayer.Entities.FuelRate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FuelManagement.Core.Services
{
    public class FuelRateService : RepositoryBase<long, FuelRate>, IFuelRateService
    {
        private readonly FuelmanagementContext _context;

        public FuelRateService(FuelmanagementContext context) : base(context)
        {
            _context = context;
        }
       
        public bool Add(CreateFuelRateDto FuelRate)
        {
            try
            {
                var fileExtension = "";
                var imageUrl = new List<string>();


                foreach (var image in FuelRate.FuelRateImage)
                {

                    //if (image.Length is >= 5097152 or <= 0) continue;
                    fileExtension = Path.GetExtension(image.FileName).Remove(0, 1);
                    var extension = image.ContentType;
                    //var convertToBase64Async = new ImageConvertor();
                    // var base64 = convertToBase64Async.ConvertToBase64Async(image);
                    var base64 = "";
                    string fileContent = "";
                    using (var reader = new StreamReader(image.OpenReadStream()))
                    {
                        fileContent = reader.ReadToEnd();

                    }
                    using (var stream = new MemoryStream())
                    {
                        image.CopyTo(stream);
                        var bytes = stream.ToArray();
                        base64 = Convert.ToBase64String(bytes);
                    }
                    var urlImage = ImageService.AddToFile(base64, fileExtension);
                    //imageUrl += (urlImage) + "" + ",";
                    imageUrl.Add(urlImage);
                }

                var FuelRateImageStr = string.Join(",", imageUrl);
                //var publishDateMiladi = ConvertShamsiToGregorian(FuelRate.PublishDate.ToString("yyyy/MM/dd"));
                //var UpdateDateMiladi = ConvertShamsiToGregorian(FuelRate.PublishDate.ToString("yyyy/MM/dd"));
                //var PublishDateJalali = "--";// FuelRate.PublishDate.ToString("yyyy/MM/dd");
                //var UpdateDateJalali = "--";// FuelRate.PublishDate.ToString("yyyy/MM/dd");


                var query = new FuelRate(
                    FuelRate.FuelType,
                    FuelRate.Amount,
                    FuelRateImageStr,
                    FuelRate.PublishDate,
                    FuelRate.UserLog ?? "System");

                Create(query);
                SaveChanges();
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(EditFuelRateDto FuelRate)
        {
            try
            {
                var editFuelRate = _context.FuelRates.FirstOrDefault(n => n.Id == FuelRate.Id);
                if (editFuelRate == null)
                    return false;

                // فایل‌ها نادیده گرفته شده
                string FuelRateImageStr = editFuelRate.FuelRateImage ?? "";

                editFuelRate.Edit(
                    FuelRate.FuelType,
                    FuelRate.Amount,
                    FuelRateImageStr,
                    FuelRate.PublishDate,
                    FuelRate.UserLog ?? "System");

                editFuelRate.IsDelete = FuelRate.IsDelete;

                SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(long id, string userLog)
        {
            try
            {
                var removeFuelRate = _context.FuelRates.FirstOrDefault(n => n.Id == id);
                if (removeFuelRate == null)
                    return false;

                removeFuelRate.Remove(userLog ?? "System");
                SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<ListFuelRateDto> GetAll(string search)
        {
            return _context.FuelRates
                .Where(x => string.IsNullOrEmpty(search) || x.FuelType.Contains(search))
                .OrderByDescending(x => x.Id)
                .Select(x => new ListFuelRateDto
                {
                    Id = x.Id,
                    FuelType = x.FuelType,
                    Amount = x.Amount,
                    IsDelete = x.IsDelete,
                    FuelRateImage = x.FuelRateImage,
                    PublishDateJalali = x.PublishDate.ToShamsi(),
                    UpdateDateJalali = x.UpdateDate.ToShamsi(),
                    UserLog = x.UserLog
                })
                .ToList();
        }

        public DetailFuelRateDto GetDetail(long id)
        {
            var FuelRate = _context.FuelRates.FirstOrDefault(n => n.Id == id);
            if (FuelRate == null) return null;

            return new DetailFuelRateDto
            {
                FuelType = FuelRate.FuelType,
                Amount = FuelRate.Amount,
                FuelRateImage = string.IsNullOrWhiteSpace(FuelRate.FuelRateImage) ? new List<string>() : FuelRate.FuelRateImage.Split(',').ToList(),
                PublishDate = FuelRate.PublishDate,
                UpdateDate = FuelRate.UpdateDate,
                PublishDateJalali = FuelRate.PublishDate.ToShamsi(),
                UpdateDateJalali = FuelRate.UpdateDate.ToShamsi(),
                UserLog = FuelRate.UserLog,
                IsDelete = FuelRate.IsDelete
            };
        }
    }
}



