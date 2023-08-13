using System;
using ApplicationLayer.Domain.Reports;


namespace ApplicationLayer.Domain.Reports;

public record AccountStatusReport
{
    public DateTime Date { get; set; } = DateTime.Now;
    public string Client { get; set; } = null!;
    public string AccountNumber { get; set; } = null!;
    public decimal InitialBalance { get; set; }
    public decimal Transaction { get; set; }
    public decimal AvailableBalance { get; set; }
}
