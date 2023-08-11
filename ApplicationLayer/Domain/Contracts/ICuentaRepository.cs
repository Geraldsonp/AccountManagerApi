namespace ApplicationLayer.Domain.Contracts;

public interface ICuentaRepository
{
    Task<Cuenta> GetByAccountNumberAsync(int accountNumber, int clientId);
    Task<List<Cuenta>> GetClientAccounts(int clientId);
    Task<bool> ExistsByAccountNumberAsync(int accountNumber, int clientId);
    Task Create(Cuenta account);
    Task Update(Cuenta account);
}