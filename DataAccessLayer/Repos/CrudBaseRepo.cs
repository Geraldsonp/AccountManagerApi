using ApplicationLayer.Domain.Contracts;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using ApplicationLayer.Domain.Exceptions;

namespace DataAccessLayer.Repos;

public abstract class CrudBaseRepo<T> : ICrud<T> where T : class
{
    private readonly AccountMngDbContext _context;

    public CrudBaseRepo(AccountMngDbContext context)
    {
        _context = context;
    }

    public async Task<T> Get(Func<T, bool> predicate)
    {
        var model = await _context.Set<T>().FirstOrDefaultAsync(x => predicate(x)) ?? throw new NotFoundException(nameof(T));
        return model;
    }

    public async Task<IEnumerable<T>> GetAll(Func<T, bool> predicate)
    {
        return await _context.Set<T>().Where(x => predicate(x)).ToListAsync();
    }

    public async Task<T> Create(T model)
    {
        await _context.Set<T>().AddAsync(model);
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task<T> Update(T model)
    {
        _context.Set<T>().Update(model);
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task Delete(T model)
    {
        _context.Set<T>().Remove(model);
        await _context.SaveChangesAsync();
    }
}