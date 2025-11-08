using DocumentFormat.OpenXml.Spreadsheet;
namespace FuelManagement.UI.Models
{
    public class ErrorViewModel
    {
           public string? RequestId { get; set; }

            public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
   
    }
}
