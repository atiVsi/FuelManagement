using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.DataLayer.Entities;

public class LogEntry
{
    public int Id { get; set; }
    public long UserId { get; set; }
    public string Username { get; set; }
    public string PageUrl { get; set; }
    public string QueryParams { get; set; }
    public string IpAddress { get; set; }
    public string BrowserInfo { get; set; }
    public string HttpMethod { get; set; }
    public DateTime Timestamp { get; set; }
}
