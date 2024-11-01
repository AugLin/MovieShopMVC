using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<int> Add(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<int> GetCount(Expression<Func<T, bool>> filter = null);
    }
}
