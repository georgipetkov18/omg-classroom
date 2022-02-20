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
        protected readonly ClassroomDbContext _context;
        protected DbSet<E> _dbSet;

        protected BaseRepository(ClassroomDbContext context)
        {
            _context = context;           
        }

        public async Task AddAsync(E entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(E entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            E entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<E> ReadAsync(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }
        public IQueryable<E> ReadAll()
        {
            return _dbSet.AsQueryable();
        }
    }
}
