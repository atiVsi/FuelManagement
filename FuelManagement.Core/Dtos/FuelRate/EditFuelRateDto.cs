using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.FuelRate;

public class EditFuelRateDto : CreateFuelRateDto
{
    public long Id { get; set; }
    public bool IsDelete { get; set; }
    public List<string>? FuelRateImages { get; set; }

}

