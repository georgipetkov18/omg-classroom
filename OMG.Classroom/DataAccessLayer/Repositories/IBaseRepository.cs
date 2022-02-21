using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IBaseRepository<E> where E : BaseEntity
    {
        public Task<E> ReadAsync(Guid id);
        public Task UpdateAsync(E role);
        public Task DeleteAsync(Guid id);
        public IQueryable<E> ReadAll();
        public Task AddAsync(E role);
    }
}
