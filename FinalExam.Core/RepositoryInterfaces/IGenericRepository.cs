using System.Linq.Expressions;
using FinalExam.Core.Entities;

namespace FinalExam.Core.RepositoryInterfaces;

public interface IGenericRepository<T> where T : BaseEntity, new()
{
    IQueryable<T> GetAll();
    IQueryable<T> FindAll(Expression<Func<T, bool>> filter);
    Task<bool> IsExist(Guid id);
    Task<T?> GetByIdAsync(Guid id);
    Task CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task DeleteByIdAsync(Guid id);
    void Delete(T entity);
    void SaveChanges();
}
