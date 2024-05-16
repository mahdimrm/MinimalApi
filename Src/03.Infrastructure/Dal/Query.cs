using Entities;
using Interfaces.Common;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Shared;
using System.Linq.Expressions;

namespace Dal
{
    public class Query<T> : IQuery<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbset;

        public Query(ApplicationDbContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }

        public async Task<T?> GetAsync(object? id)
           => await _dbset.FindAsync(id);


        public async Task<T?> FirstOrDefault(Expression<Func<T, bool>> expression)
            => await _dbset.FirstOrDefaultAsync(expression);

        //Get Data With Out Pagination

        public async Task<IEnumerable<T>> GetAllAsync()
             => await _dbset.AsNoTracking().ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression)
            => await _dbset.AsNoTracking().Where(expression).ToListAsync();

        public async Task<IEnumerable<TType>> GetAllAsync<TType>(Expression<Func<T, TType>> select) where TType : class
            => await _dbset.Select(select).ToListAsync();


        public async Task<IEnumerable<TType>> GetAllAsync<TType>(Expression<Func<T, bool>> expression, Expression<Func<T, TType>> select) where TType : class
            => await _dbset.Where(expression).Select(select).ToListAsync();

        //Get Data With Paginated 

        public ApiPagedList<T> GetPagedList(int pageNumber, int pageSize)
            => new ApiPagedList<T>(pageNumber, pageSize, _dbset);

        public ApiPagedList<T> GetPaginated(int pageNumber, int pageSize, Expression<Func<T, bool>> expression)
            => new ApiPagedList<T>(pageNumber, pageSize, _dbset.Where(expression));

        public ApiPagedList<TType> GetPaginated<TType>(int pageNumber, int pageSize, Expression<Func<T, bool>> expression, Expression<Func<T, TType>> select) where TType : class
                        => new ApiPagedList<TType>(pageNumber, pageSize, _dbset.Where(expression).Select(select));

        public ApiPagedList<TType> GetPagedList<TType>(int pageNumber, int pageSize, Expression<Func<T, bool>> expression, Expression<Func<T, TType>> select) where TType : class
            => new ApiPagedList<TType>(pageNumber, pageSize, _dbset.Where(expression).Select(select));


        public ApiPagedList<T> GetPagedList(int page, int count, Expression<Func<T, bool>> expression)
            => new ApiPagedList<T>(page, count, _dbset.Where(expression));

        public ApiPagedList<TType> GetPagedList<TType>(int pageNumber, int pageSize, Expression<Func<T, TType>> select) where TType : class
            => new ApiPagedList<TType>(pageNumber, pageSize, _dbset.Select(select));
    }
}
