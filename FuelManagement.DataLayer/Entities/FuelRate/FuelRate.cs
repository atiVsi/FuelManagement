using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.DataLayer.Entities.FuelRate;

public class FuelRate : EntityBase
{
    [Display(Name = "عنوان")]
    public string FuelType { get; private set; }

    [Display(Name = "مبلغ")]
    public string? Amount { get; private set; }

    [Display(Name = "فایل پیوست")]
    public string FuelRateImage { get; private set; }

    public DateTime PublishDate { get; private set; } = DateTime.Now;

    public DateTime UpdateDate { get; private set; } = DateTime.Now;
    public string PublishDateJalali { get; private set; } = string.Empty;
    public string UpdateDateJalali { get; private set; } = string.Empty;
    public FuelRate() { }

    public FuelRate(string fuelType, string amount, string fuelRateImage, DateTime publishDate, string userLog)
    {
        FuelType = fuelType;
        Amount = amount;
        FuelRateImage = fuelRateImage;
        PublishDate = publishDate;
        UpdateDate = DateTime.Now;

        PublishDateJalali = "—";   // مقدار موقت
        UpdateDateJalali = "—";

        UserLog = userLog;
    }

    public void Edit(string FuelType, string Amount, string FuelRateImage, DateTime publishDate, string userLog)
    {
        this.FuelType = FuelType;
        this.Amount = Amount;
        this.FuelRateImage = FuelRateImage;
        this.PublishDate = publishDate;
        this.UserLog = userLog;

    }

    public void Remove(string userLog)
    {
        UserLog = userLog;
        IsDelete = true;
    }
}
