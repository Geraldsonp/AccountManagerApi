using System.Linq.Expressions;

namespace ApplicationLayer.Domain.Contracts;

public interface ICrud<T> where T : class
{
    Task<T> Get(Func<T, bool> predicate);
    Task<IEnumerable<T>> GetAll(Func<T, bool> predicate);
    Task<T> Create(T model);
    Task<T> Update(T model);
    Task Delete(T model);
}