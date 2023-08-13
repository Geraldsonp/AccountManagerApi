using System.Transactions;
using ApplicationLayer.Domain.Enums;
using ApplicationLayer.Domain.Utils;

namespace ApplicationLayer.Domain.Models;

public class Account
{
    public string AccountNumber { get; set; } = null!;

    public AccountType AccountType { get; set; }

    public decimal InitialBalance { get; set; }

    public Status Status { get; set; } = Status.Active;

    public int ClientId { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; } = new List<Transaction>();

    private readonly decimal DailyLimit = 1000;


    public decimal GetCurrentBalance()
    {
        var currentBalance = Transactions.LastOrDefault()?.AvailableBalance ?? InitialBalance;
        return currentBalance;
    }

    private decimal VerifyDailyWithdrawalLimit(decimal amount)
    {
        var todaysDebitsAmount = Transactions
            .Where(t => t.Date.Date == DateTime.Now.Date && t.TransactionType == TransactionType.Debit)
            .Sum(t => t.Amount);

        var totalDebitsAmount = Math.Abs(todaysDebitsAmount + amount);

        if (totalDebitsAmount >= DailyLimit)
            throw new TransactionException("Daily withdrawal limit exceeded");

        return todaysDebitsAmount;
    }

    private bool CanWithDrawAmount(decimal amount)
    {
        var currentBalance = Transactions.LastOrDefault()?.AvailableBalance ?? InitialBalance;

        if (currentBalance + amount < 0)
            throw new TransactionException("Insufficient funds");

        return true;
    }

    public decimal ProccesTransaction(Transaction transaction)
    {
        if (transaction.TransactionType == TransactionType.Debit)
        {
            VerifyDailyWithdrawalLimit(transaction.Amount);
            CanWithDrawAmount(transaction.Amount);
        }

        transaction.AvailableBalance = GetCurrentBalance() + transaction.Amount;
        Transactions.Add(transaction);

        return transaction.AvailableBalance;
    }
}
