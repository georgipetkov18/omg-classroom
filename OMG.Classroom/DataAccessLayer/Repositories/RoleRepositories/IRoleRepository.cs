using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.RoleRepositories
{
    public interface IRoleRepository
    {
        public void Add(Role role);
        public Role Read(Guid id);
        public IQueryable<Role> ReadAll();
        public void Update(Role role);
        public void Delete(Guid id);
    }
}
