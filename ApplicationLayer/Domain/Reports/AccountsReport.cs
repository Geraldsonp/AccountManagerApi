using System;
using ApplicationLayer.Domain.Reports;


namespace ApplicationLayer.Domain.Reports;

public record AccountStatusReport
{
    public int ClientId { get; set; }
    public List<AccountStatus> Accounts { get; set; } = new List<AccountStatus>();
}
