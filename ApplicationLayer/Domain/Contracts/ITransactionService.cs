using System;

namespace ApplicationLayer.Domain.Contracts
{
    public interface ITransactionService
    {
        Task<Transaction> GetTransactionAsync(int transactionId, string accountNumber);
        Task<IEnumerable<Transaction>> GetTransactionsAsync(string accountNumber);
        Task<Transaction> CreateTransactionAsync(string accountNumber, decimal amount);
        Task DeleteTransactionAsync(int transactionId, string accountNumber);

    }
}
