using ApplicationLayer.Domain;
using ApplicationLayer.Domain.Contracts;
using ApplicationLayer.Domain.Enums;

namespace ApplicationLayer.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }
    public async Task<Cuenta> CreateAccountAsync(decimal initialBalance, AccountType accountType, int clientId)
    {
        var account = new Cuenta
        {
            SaldoInicial = initialBalance,
            TipoCuenta = accountType.ToString(),
            Estado = AccountStatus.Active.ToString(),
            ClienteId = clientId
        };

        await _accountRepository.Create(account);

        return account;
    }

    public Task<Cuenta> GetAccountByClientAsync(int accountNumber, int clientId)
    {
        var account = _accountRepository.Get(c => c.NumeroCuenta == accountNumber && c.ClienteId == clientId);
        return account;
    }

    public async Task<IEnumerable<Cuenta>> GetAccountsByClientAsync(int clientId)
    {
        return await _accountRepository.GetAll(x => x.ClienteId == clientId);
    }

    public async Task<Cuenta> UpdateAccountStatusAsync(AccountStatus accountStatus, int AccountNumber)
    {
        var account = await _accountRepository.Get(c => c.NumeroCuenta == AccountNumber);
        account.Estado = accountStatus.ToString();
        await _accountRepository.Update(account);
        return account;
    }

    public Task<Cuenta> GetAccountAsync(int id)
    {
        return _accountRepository.Get(c => c.NumeroCuenta == id);
    }
    public async Task<IEnumerable<Cuenta>> GetAccountsAsync()
    {
        return await _accountRepository.GetAll(c => true);
    }
}