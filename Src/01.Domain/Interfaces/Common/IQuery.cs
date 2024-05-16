using Entities;
using Shared;
using System.Linq.Expressions;

namespace Interfaces.Common
{
    public interface IQuery<T> where T : BaseEntity
    {
        //Get
        Task<T> GetAsync(object? id);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> expression);

        // Get Data With Out Pagination
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<TType>> GetAllAsync<TType>(Expression<Func<T, TType>> select) where TType : class;
        Task<IEnumerable<TType>> GetAllAsync<TType>(Expression<Func<T, bool>> expression, Expression<Func<T, TType>> select) where TType : class;

        //Get Data With Pagination
        ApiPagedList<T> GetPagedList(int pageNumber, int pageSize);
        ApiPagedList<TType> GetPagedList<TType>(int pageNumber, int pageSize, Expression<Func<T, TType>> select) where TType : class;
        ApiPagedList<T> GetPagedList(int pageNumber, int pageSize, Expression<Func<T, bool>> expression);
        ApiPagedList<TType> GetPagedList<TType>(int pageNumber, int pageSize, Expression<Func<T, bool>> expression, Expression<Func<T, TType>> select) where TType : class;
    }
}
