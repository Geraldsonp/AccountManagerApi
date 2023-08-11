using System.Linq.Expressions;

namespace ApplicationLayer.Domain.Contracts;

public interface ICrud<T> where T : class
{
    Task<T?> Get(int id);
    Task<IEnumerable<T>> Get();
    Task<T> Create(T model);
    Task<T> Update(T model);
    Task Delete(T model);
}