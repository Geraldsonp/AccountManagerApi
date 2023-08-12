using ApplicationLayer.Domain;
using DataAccessLayer.Models;
using ApplicationLayer.Domain.Contracts;
using ApplicationLayer.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace DataAccessLayer.Repos;

public class AccountRepository : CrudBaseRepo<Account>, IAccountRepository
{
    private readonly AccountsManagerDbContext _context;

    public AccountRepository(AccountsManagerDbContext context) : base(context)
    {
        _context = context;
    }
}