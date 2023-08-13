using System;

namespace ApplicationLayer.Domain.Reports;

public record AccountStatus
{
    public string AccountNumber { get; set; }
    public decimal CurrentBalance { get; set; }
    public decimal DebitsTotal { get; set; }
    public decimal CreditsTotal { get; set; }
}
