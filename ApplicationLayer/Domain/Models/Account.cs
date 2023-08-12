using ApplicationLayer.Domain.Enums;

namespace ApplicationLayer.Domain;

public class Account
{
    public string AccountNumber { get; set; } = null!;

    public AccountType AccountType { get; set; }

    public decimal InitialBalance { get; set; }

    public Status Status { get; set; } = Status.Active;

    public int ClientId { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
