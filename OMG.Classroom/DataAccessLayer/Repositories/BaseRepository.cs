using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public abstract class BaseRepository<E> where E : BaseEntity
    {
        public readonly ClassroomDbContext _context;
        public readonly DbSet<E> _dbSet;

        protected BaseRepository(ClassroomDbContext context, DbSet<E> dbSet)
        {
            _context = context;
            _dbSet = dbSet;
        }

        public async Task Add(E entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Update(E entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Guid id)
        {
            E entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<E> Read(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<ICollection<E>> ReadAll()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
