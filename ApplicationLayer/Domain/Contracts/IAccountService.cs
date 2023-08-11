using ApplicationLayer.Domain;
using ApplicationLayer.Domain.Enums;

namespace ApplicationLayer.Services;

public interface IAccountService
{
    Task<Cuenta> GetAccountAsync(int id);
    Task<Cuenta> GetAccountByClientAsync(int id, int clientId);
    Task<IEnumerable<Cuenta>> GetAccountsAsync();
    Task<IEnumerable<Cuenta>> GetAccountsByClientAsync(int clientId);
    Task<Cuenta> CreateAccountAsync(decimal initialBalance, AccountType accountType, int clientId);
    Task<Cuenta> UpdateAccountStatusAsync(AccountStatus accountStatus, int AccountNumber);
}