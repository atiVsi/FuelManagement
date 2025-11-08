using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.News;

public class ListNewsDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string DescriptionNews { get; set; }
    public string PublishDateShamsi { get; set; }
    public bool IsPublished { get; set; }
    public bool IsDelete { get; set; }
    public string NewsImage { get; set; }
    public string CreationDate { get; set; }
    public string UserLog { get; set; }
    public string? Filetype { get; set; }
}
