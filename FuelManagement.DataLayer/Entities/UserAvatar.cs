using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.DataLayer.Entities.User;

public class UserAvatar : EntityBase
{
    [Display(Name = "عکس بند انگشتی")]
    public string? tinyField { get; private set; }
    [Display(Name = "عکس کوچک")]
    public string? smallField { get; private set; }
    [Display(Name = "عکس متوسط")]
    public string? mediumField { get; private set; }
    [Display(Name = "عکس بزرگ")]
    public string? largeField { get; private set; }
    [Display(Name = "عکس اصلی")]
    public string? masterField { get; private set; }

    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public long UserId { get; private set; }


    #region Relations 
    // هر کاربر یک تصویر دارد

    [ForeignKey("UserId")]
    public User User { get; private set; }
    #endregion

    public UserAvatar(long id, string tinyField, string smallField, string mediumField, string largeField, string masterField, long userId)
    {
        Id = id;
        this.tinyField = tinyField;
        this.smallField = smallField;
        this.mediumField = mediumField;
        this.largeField = largeField;
        this.masterField = masterField;
        UserId = userId;
    }


    public UserAvatar(string tinyField, string smallField, string mediumField, string largeField, string masterField, long userId)
    {
        this.tinyField = tinyField;
        this.smallField = smallField;
        this.mediumField = mediumField;
        this.largeField = largeField;
        this.masterField = masterField;
        UserId = userId;
    }
}

