using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Dtos.Proposal;

public class EditProposalcall:CreateProposalcall
{
    public long Id { get; set; }
    public string? OrganizationTitle { get; set; }
}
