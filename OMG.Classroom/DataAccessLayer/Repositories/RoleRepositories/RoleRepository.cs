using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.RoleRepositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ClassroomDbContext _dbContext;

        public RoleRepository(ClassroomDbContext context)
        {
            _dbContext = context;
        }

        public void Add(Role role)
        {
            _dbContext.Roles.Add(role);
            _dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Role role = _dbContext.Roles.Find(id);
            if (role == null)
            {
                //Ако нещо подаде невалидно ид - малко се филмирах
                throw new ArgumentNullException("No such role");
            }
            _dbContext.Roles.Remove(role);
            _dbContext.SaveChanges();
        }

        public Role Read(Guid id)
        {
            Role role = _dbContext.Roles.Find(id);
            if (role == null)
            {
                //Ако нещо подаде невалидно ид - малко се филмирах
                throw new ArgumentNullException("No such role");
            }
            return role;
        }

        public IQueryable<Role> ReadAll()
        {
            return _dbContext.Roles.AsQueryable();
        }

        public void Update(Role newRole)
        {
            _dbContext.Roles.Update(newRole);

            //Role role = _dbContext.Roles.Find(newRole.Id);
            //if (role == null)
            //{
            //    //Ако нещо подаде невалидно ид - малко се филмирах
            //    throw new ArgumentNullException("No such role");
            //}
            //_dbContext.Entry(role).CurrentValues.SetValues(newRole);
            //_dbContext.SaveChanges();
        }
    }
}
