using ApplicationLayer.Domain;
using DataAccessLayer.Models;
using ApplicationLayer.Domain.Contracts;
using ApplicationLayer.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ApplicationLayer.Domain.Models;

namespace DataAccessLayer.Repos;

public class AccountRepository : CrudBaseRepo<Account>, IAccountRepository
{
    private readonly AccountsManagerDbContext _context;

    public AccountRepository(AccountsManagerDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Account> GetAccountWithTransactions(string accountNumber, int clientId)
    {
        return await _context.Accounts.Where(a => a.AccountNumber == accountNumber && a.ClientId == clientId)
            .Include(a => a.Transactions)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(Account), accountNumber);
    }

    public async Task<Account> GetAccountWithTransactions(string accountNumber)
    {
        return await _context.Accounts.Where(a => a.AccountNumber == accountNumber)
            .Include(a => a.Transactions)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(Account), accountNumber);
    }

    public async Task<IEnumerable<Account>> GetAccountsWithTransactions(int? clientId = null)
    {
        if (clientId == null)
            return await _context.Accounts.Include(a => a.Transactions).ToListAsync();

        return await _context.Accounts.Where(a => a.ClientId == clientId).Include(a => a.Transactions).ToListAsync();
    }
}