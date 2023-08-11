using ApplicationLayer.Domain;
using DataAccessLayer.Models;
using ApplicationLayer.Domain.Contracts;
using ApplicationLayer.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repos;

public class CuentaRepo : ICuentaRepository
{
    private readonly AccountMngDbContext _context;

    public CuentaRepo(AccountMngDbContext context)
    {
        _context = context;
    }

    public async Task<Cuenta> GetByAccountNumberAsync(int accountNumber, int clientId)
    {
        //Todo: Make Account number in db string
        var account = _context.Cuenta.Where(cuenta => cuenta.NumeroCuenta == accountNumber && cuenta.ClienteId == clientId);

        return await account.FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(account), accountNumber);
    }

    public Task<bool> ExistsByAccountNumberAsync(int accountNumber, int clientId)
    {
        return _context.Cuenta.AnyAsync(c => c.NumeroCuenta == accountNumber && c.ClienteId == clientId);
    }

    public Task<List<Cuenta>> GetClientAccounts(int clientId)
    {
        return _context.Cuenta.Where(cuenta => cuenta.ClienteId == clientId).ToListAsync();
    }

    public Task Create(Cuenta account)
    {
        _context.Cuenta.Add(account);
        return _context.SaveChangesAsync();
    }

    public Task Update(Cuenta account)
    {
        _context.Cuenta.Update(account);
        return _context.SaveChangesAsync();
    }
}