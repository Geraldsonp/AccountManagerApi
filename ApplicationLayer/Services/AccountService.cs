using ApplicationLayer.Domain;
using ApplicationLayer.Domain.Contracts;
using ApplicationLayer.Domain.Enums;
using ApplicationLayer.Domain.Models;

namespace ApplicationLayer.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }
    public async Task<Account> CreateAccountAsync(decimal initialBalance, AccountType accountType, int clientId)
    {
        var account = new Account
        {
            InitialBalance = initialBalance,
            AccountType = accountType,
            Status = Status.Active,
            ClientId = clientId
        };

        await _accountRepository.Create(account);

        return account;
    }

    public Task<Account> GetAccountByClientAsync(string accountNumber, int clientId)
    {
        var account = _accountRepository.GetAccountWithTransactions(accountNumber, clientId);
        return account;
    }

    public async Task<IEnumerable<Account>> GetAccountsByClientAsync(int clientId)
    {
        return await _accountRepository.GetAccountsWithTransactions(clientId);
    }

    public async Task<Account> UpdateAccountStatusAsync(Status accountStatus, string AccountNumber)
    {
        var account = await _accountRepository.Get(c => c.AccountNumber == AccountNumber);
        account.Status = accountStatus;
        await _accountRepository.Update(account);
        return account;
    }

    public Task<Account> GetAccountAsync(string id)
    {
        return _accountRepository.GetAccountWithTransactions(id); ;
    }
    public async Task<IEnumerable<Account>> GetAccountsAsync()
    {
        return await _accountRepository.GetAccountsWithTransactions();
    }

}