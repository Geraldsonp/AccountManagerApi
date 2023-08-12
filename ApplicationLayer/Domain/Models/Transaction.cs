namespace ApplicationLayer.Domain;

public class Transaction
{
    public int TransactionId { get; set; }

    public string? AccountNumber { get; set; }

    public DateTime Date { get; set; }

    public string TransactionType { get; set; } = null!;

    public decimal Amount { get; set; }

    public decimal Balance { get; set; }

    public virtual Account? AccountNumberNavigation { get; set; }
}
