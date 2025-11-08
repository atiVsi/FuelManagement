using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.OrganizationDto;

public class OrganizationQueryModel
{
    public long Id { get; set; }

    [Display(Name = "عنوان منطقه")]
    public string Title { get; set; }

    public bool IsDeleted { get; set; }
}
