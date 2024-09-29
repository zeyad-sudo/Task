using Microsoft.EntityFrameworkCore.Storage;
using Task.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace MS.Infrastructure.Repositories.Generics
{
    public interface IBaseRepository<T> where T:class
    {
        System.Threading.Tasks.Task DeleteRangeAsync(ICollection<T> entities);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(int Skip, int Take);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, object>>[] includes = null);
        Task<IEnumerable<T>>GetByNameAsync(Expression<Func<T,bool>>expression,string name);
        System.Threading.Tasks.Task SaveChangesAsync();
        IDbContextTransaction BeginTransaction();
        void Commit();
        void RollBack();
        IQueryable<T> GetTableNoTracking();
        IQueryable<T> GetTableAsTracking();
        Task<T> AddAsync(T entity);
        System.Threading.Tasks.Task AddRangeAsync(ICollection<T> entities);
        System.Threading.Tasks.Task UpdateAsync(T entity);
        System.Threading.Tasks.Task UpdateRangeAsync(ICollection<T> entities);
        System.Threading.Tasks.Task DeleteAsync(T entity);
        Task<T> GetByExpressionSingleAsync(Expression<Func<T, bool>> expression, Expression<Func<T, object>>[] includes = null);
        Task<IEnumerable<T>> GetByExpressionAsync(Expression<Func<T, bool>> expression, Expression<Func<T, object>>[] includes = null);
        Task<IEnumerable<T>> GetByExpressionAsync(int Skip , int Take, Expression<Func<T, bool>> expression);
        Task<int> CountAsync(Expression<Func<T, bool>>? expression=default);
    }
}
