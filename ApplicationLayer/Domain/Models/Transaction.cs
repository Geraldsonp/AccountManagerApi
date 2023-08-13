using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ApplicationLayer.Domain.Enums;
using ApplicationLayer.Domain.Models;

namespace ApplicationLayer.Domain;

public class Transaction
{
    public int TransactionId { get; set; }

    public string? AccountNumber { get; set; }

    public DateTime Date { get; set; }

    public decimal Amount { get; set; }
    public TransactionType TransactionType { get; set; }

    [Column("Balance")]
    public decimal AvailableBalance { get; set; }

    [JsonIgnore]
    public virtual Account? AccountNumberNavigation { get; set; }

    public Transaction(decimal amount, string accountNumber)
    {
        Amount = amount;
        Date = DateTime.Now;
        TransactionType = amount > 0 ? TransactionType.Credit : TransactionType.Debit;
        AccountNumber = accountNumber;
    }

    private Transaction()
    {
    }

}
