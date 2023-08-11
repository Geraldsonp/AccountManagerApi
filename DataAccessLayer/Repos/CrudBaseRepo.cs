using ApplicationLayer.Domain.Contracts;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repos;

public abstract class CrudBaseRepo<T> : ICrud<T> where T : class
{
    private readonly AccountMngDbContext _context;

    public CrudBaseRepo(AccountMngDbContext context)
    {
        _context = context;
    }
    public async Task<T?> Get(int id)
    {
        return  await _context.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> Get()
    {
        return await _context.Set<T>().ToListAsync();
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