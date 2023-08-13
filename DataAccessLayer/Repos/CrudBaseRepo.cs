using ApplicationLayer.Domain.Contracts;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using ApplicationLayer.Domain.Exceptions;
using System.Linq.Expressions;

namespace DataAccessLayer.Repos;

public abstract class CrudBaseRepo<T> : ICrud<T> where T : class
{
    private readonly AccountsManagerDbContext _context;

    public CrudBaseRepo(AccountsManagerDbContext context)
    {
        _context = context;
    }

    public async Task<T> Get(Expression<Func<T, bool>> predicate)
    {
        var model = await _context.Set<T>().FirstOrDefaultAsync(predicate) ?? throw new NotFoundException(typeof(T).Name);
        return model;
    }

    public async Task<List<T>> GetAll(Expression<Func<T, bool>>? predicate = null)
    {
        List<T> models;

        if (predicate == null)
        {
            models = await _context.Set<T>().ToListAsync();
            return models;
        }

        models = _context.Set<T>().Where(predicate).ToList();
        return models;
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