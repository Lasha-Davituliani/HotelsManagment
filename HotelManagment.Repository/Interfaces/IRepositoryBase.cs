using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace HotelManagment.Repository.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter, string includeProperties = null);
        Task<List<T>> GetAllAsync(string includeProperties = null);
        Task<T> GetAsync(Expression<Func<T,bool>> filter);
        Task AddAsync(T entity);
        Task RemoveAsync(T entity);
    }
}
