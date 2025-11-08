using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.News;

public class EditNewsDto : CreateNewsDto
{
    public long Id { get; set; }
    public bool IsDelete { get; set; }
    public List<string>? NewsImages { get; set; }

}
