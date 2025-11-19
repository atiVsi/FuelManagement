using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.DataLayer.Entities;

public class EntityBase
{
    [Key]
    public long Id { get; set; }
    
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public bool IsDelete { get; set; }

    //کد ملی کاربری که آخرین تغییر را انجام داده
    [Display(Name = "ثبت شده توسط")]
    public string? UserLog { get; set; }
}

