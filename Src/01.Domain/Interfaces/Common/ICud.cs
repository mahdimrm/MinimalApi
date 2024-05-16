using Entities;
using System.Linq.Expressions;

namespace Interfaces.Common
{
    public interface ICud<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(IEnumerable<T> entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> UpdateRangeAsync(IEnumerable<T> entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> DeleteByIdAsync(Guid Guid);
        Task<bool> DeleteAsync(Expression<Func<T, bool>> where);
        Task<bool> SaveAsync();
    }
}
