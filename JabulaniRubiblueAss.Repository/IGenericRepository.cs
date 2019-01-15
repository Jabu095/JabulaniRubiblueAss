using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabulaniRubiblueAss.Repository
{
    public interface IGenericRepository<T>
    {
        Task<T> GetAsync(int id);
        IQueryable<T> Query();
        Task<int> InsertAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
    }
}
