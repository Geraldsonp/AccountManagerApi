using ApplicationLayer.Domain.Models;

namespace ApplicationLayer.Domain.Contracts;

public interface IAccountRepository : ICrud<Account>
{
    public Task<Account> GetAccountWithTransactions(string accountNumber, int clientId);
    public Task<Account> GetAccountWithTransactions(string accountNumber);
    public Task<IEnumerable<Account>> GetAccountsWithTransactions(int? clientId = null);
    public Task<bool> DoesAccountExist(string accountNumber);
}