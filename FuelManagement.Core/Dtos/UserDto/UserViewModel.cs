using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.UserDto;

public class UserViewModel
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Sex { get; set; }
    public string IsInsurance { get; set; }
    public string NationalCode { get; set; }
    public string PersonalCode { get; set; }
    public string EmploymentStatus { get; set; }
    public bool IsEmployeeField { get; set; }
    public DateTime? RegisteriDate { get; set; }

    public string? RegisteriDate_fa { get; set; }
    public bool IsDelete { get; set; }
}
