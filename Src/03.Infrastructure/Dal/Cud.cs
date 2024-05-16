using Entities;
using Interfaces.Common;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Linq.Expressions;

namespace Dal
{
    public class Cud<T> : ICud<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbset;

        public Cud(ApplicationDbContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }

        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                await _dbset.AddAsync(entity);
                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> AddRangeAsync(IEnumerable<T> entity)
        {
            try
            {
                await _dbset.AddRangeAsync(entity);
                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _dbset.Update(entity);
                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateRangeAsync(IEnumerable<T> entity)
        {
            try
            {
                _dbset.UpdateRange(entity);
                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteByIdAsync(Guid Guid)
        {
            try
            {
                var entity = await _dbset.FindAsync(Guid);
                _dbset.Remove(entity);
                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                _dbset.Remove(entity);
                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> SaveAsync()
        {
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> where)
        {
            try
            {
                var T = await _dbset.FindAsync(where);
                _dbset.Remove(T);
                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }
    }
}

