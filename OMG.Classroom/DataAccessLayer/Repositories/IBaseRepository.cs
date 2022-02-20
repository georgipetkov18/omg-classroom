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
        public Task<E> Read(Guid id);
        public Task Update(E role);
        public Task Delete(Guid id);
        public Task<ICollection<E>> ReadAll();
        public Task Add(E role);
    }
}
