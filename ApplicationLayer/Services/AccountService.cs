using ApplicationLayer.Domain;
using ApplicationLayer.Domain.Contracts;
using ApplicationLayer.Domain.Enums;
using ApplicationLayer.Domain.Exceptions;
using ApplicationLayer.Domain.Models;

namespace ApplicationLayer.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IClientRepository _clientRepository;

    public AccountService(IAccountRepository accountRepository, IClientRepository clientRepository)
    {
        _accountRepository = accountRepository;
        _clientRepository = clientRepository;
    }
    public async Task<Account> CreateAccountAsync(Account account)
    {
        if (await _accountRepository.DoesAccountExist(account.AccountNumber))
            throw new DomainException("Account already exists");

        if (await _clientRepository.DoesClientExist(account.ClientId) == false)
            throw new NotFoundException("Client does not exist");

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