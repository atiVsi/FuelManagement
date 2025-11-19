using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.FuelRate;

public class ListFuelRateDto
{
    public long Id { get; set; }
    public string FuelType { get; set; }
    public string? Amount { get; set; }

    public bool IsDelete { get; set; }
    public string FuelRateImage { get; set; }
    public string PublishDate { get; set; }
    public string UpdateDate { get; set; }
    public string UserLog { get; set; }
    public string? PublishDateJalali { get; set; }
    public string? UpdateDateJalali { get; set; }
}

