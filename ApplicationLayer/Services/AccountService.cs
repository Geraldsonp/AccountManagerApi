using ApplicationLayer.Domain;
using ApplicationLayer.Domain.Contracts;
using ApplicationLayer.Domain.Enums;
using ApplicationLayer.Domain.Exceptions;
using ApplicationLayer.Domain.Models;

namespace ApplicationLayer.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }
    public async Task<Account> CreateAccountAsync(Account account)
    {
        if (await _accountRepository.DoesAccountExist(account.AccountNumber))
            throw new DomainException("Account already exists");

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

    public async Task DeleteAccountAsync(string accountNumber)
    {
        var account = await _accountRepository.Get(c => c.AccountNumber == accountNumber);
        await _accountRepository.Delete(account);
    }
}