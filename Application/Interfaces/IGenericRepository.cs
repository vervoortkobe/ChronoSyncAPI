using System.Linq.Expressions;

namespace Application.Interfaces;

public interface IGenericRepository<T>
{
    Task<IEnumerable<T>> GetAll(int pageNr, int pageSize);
    Task<T?> GetById(string id);
    Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
    Task<T> Create(T newObject);
    Task<T> Update(string id, T modifiedObject);
    Task Delete(string id);
}