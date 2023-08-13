using System.Linq.Expressions;

namespace ApplicationLayer.Domain.Contracts;

public interface ICrud<T> where T : class
{
    Task<T> Get(Expression<Func<T, bool>> predicate);
    Task<List<T>> GetAll(Expression<Func<T, bool>>? predicate = null);
    Task<T> Create(T model);
    Task<T> Update(T model);
    Task Delete(T model);
}