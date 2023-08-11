using ApplicationLayer.Domain;
using ApplicationLayer.Domain.Contracts;
using ApplicationLayer.Domain.Enums;

namespace ApplicationLayer.Services;

public class AccountService : IAccountService
{
    private readonly ICuentaRepository _accountRepository;
    public AccountService(ICuentaRepository accountRepository)
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

    public Task<Cuenta> GetAccountAsync(int accountNumber, int clientId)
    {
        var account = _accountRepository.GetByAccountNumberAsync(accountNumber, clientId);
        return account;
    }

    public Task<IEnumerable<Cuenta>> GetAccountsAsync(int clientId)
    {
        return await _accountRepository.Get(clientId);
    }

    public Task<Cuenta> UpdateAccountStatusAsync(AccountStatus accountStatus, int AccountNumber)
    {
        var account = _accountRepository.GetByAccountNumberAsync(AccountNumber);
        account.Estado = accountStatus.ToString();
        await _accountRepository.Update(account);
        return account;
    }
}