using ApplicationLayer.Domain;
using ApplicationLayer.Domain.Enums;
using ApplicationLayer.Domain.Models;

namespace ApplicationLayer.Services;

public interface IAccountService
{
    Task<Account> GetAccountAsync(string id);
    Task<IEnumerable<Account>> GetAccountsAsync();
    Task<Account> GetAccountByClientAsync(string id, int clientId);
    Task<IEnumerable<Account>> GetAccountsByClientAsync(int clientId);
    Task<Account> CreateAccountAsync(Account account);
    Task<Account> UpdateAccountStatusAsync(Status accountStatus, string AccountNumber);
    Task DeleteAccountAsync(string accountNumber);
}