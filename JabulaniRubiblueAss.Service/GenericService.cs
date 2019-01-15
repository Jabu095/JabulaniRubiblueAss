using JabulaniRubiblueAss.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JabulaniRubiblueAss.Service
{
    public abstract class GenericService<T>: IGenericService<T>
        where T: class,new()
    {
        protected IGenericRepository<T> EntityRepository { get; }
        protected GenericService(IGenericRepository<T> entityRepository)
        {
            EntityRepository = entityRepository;
        }
        public async Task<int> DeleteAsync(T entity)
        {
            return await EntityRepository.DeleteAsync(entity);
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await EntityRepository.Query().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await EntityRepository.GetAsync(id);
        }

        public async Task<int> InsertAsync(T entity)
        {
            return await EntityRepository.InsertAsync(entity);
        }

        public async Task<int> UpdateAsync(T entity)
        {
            return await EntityRepository.UpdateAsync(entity);
        }
    }
}
