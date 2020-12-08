using Domain.Domain.Models.Base;
using Domain.Domain.RepositoriesContracts.IBase;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity
    {
        private readonly ISystemContext _context;

        public BaseRepository(ISystemContext context)
        {
            _context = context;
        }

        public BaseRepository()
        {
        }

        public virtual async Task<T> AddAsync(T source)
        {
            _context.Db.Entry(source).State = EntityState.Added;
            _context.Db.Add(source);

            _context.Db.SaveChanges();
            return await Task.FromResult(source);
        }

        public virtual async Task<IEnumerable<T>> AddAllAsync(IEnumerable<T> source)
        {
            foreach (var item in source)
            {
                _context.Db.Entry<T>(item).State = EntityState.Added;
            }

            _context.Db.Set<T>().AddRange(source);

            await _context.Db.SaveChangesAsync();
            return await Task.FromResult(source);
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            var source = await GetByIdAsync(id);
            if (source != null)
            {
                return await DeleteAsync(source) != null;
            }

            return false;
        }

        public virtual async Task DeleteAllAsync(IEnumerable<T> source)
        {
            foreach (var item in source)
            {
                await DeleteAsync(item);
            }
        }

        public virtual async Task<T> DeleteAsync(T source)
        {
            _context.Db.Entry(source).State = EntityState.Deleted;
            _context.Db.Set<T>().Remove(source);

            await _context.Db.SaveChangesAsync();
            return await Task.FromResult(source);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(Func<T, bool> predicate = null, string[] includes = null)
        {
            var result = predicate != null ? _context.Db.Set<T>().Where(predicate).AsQueryable() : _context.Db.Set<T>().AsQueryable();
            if (result != null)
            {
                if (includes != null && includes.Length > 0)
                {
                    for (int i = 0; i < includes.Length; i++)
                    {
                        result = result.Include(includes[i]);
                    }
                }
            }

            return await Task.FromResult(result);
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Db.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> GetFirstOrDefaultAsync(Func<T, bool> predicate)
        {
            var result = _context.Db.Set<T>().FirstOrDefault(predicate);
            return await Task.FromResult(result);
        }

        public virtual async Task<T> UpdateAsync(T source)
        {
            //_context.Db.Entry(sourceOld).CurrentValues.SetValues(source);
            _context.Db.SaveChanges();
            return await Task.FromResult(source);
        }
    }
}
