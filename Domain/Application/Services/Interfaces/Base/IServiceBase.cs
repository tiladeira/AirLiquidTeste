using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Application.Services.Interfaces.Base
{
    public interface IServiceBase<T> where T : class
    {
        Task<T> AddAsync(T source);

        Task<IEnumerable<T>> AddAllAsync(IEnumerable<T> source);

        Task<bool> DeleteAsync(Guid id);

        Task DeleteAllAsync(IEnumerable<T> source);

        Task<IEnumerable<T>> GetAllAsync(Func<T, bool> predicate = null, string[] includes = null);

        Task<T> GetByIdAsync(Guid id);

        Task<T> GetFirstOrDefaultAsync(Func<T, bool> predicate);

        Task<T> UpdateAsync(T source);
    }
}
