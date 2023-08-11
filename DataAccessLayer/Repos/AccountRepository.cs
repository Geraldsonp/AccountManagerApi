using ApplicationLayer.Domain;
using DataAccessLayer.Models;
using ApplicationLayer.Domain.Contracts;
using ApplicationLayer.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace DataAccessLayer.Repos;

public class AccountRepository : CrudBaseRepo<Cuenta>, IAccountRepository
{
    private readonly AccountMngDbContext _context;

    public AccountRepository(AccountMngDbContext context) : base(context)
    {
        _context = context;
    }
}