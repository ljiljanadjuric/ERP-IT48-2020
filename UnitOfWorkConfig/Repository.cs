using Microsoft.EntityFrameworkCore;
using ProdavnicaObuce.Interface;
using ProdavnicaObuce.Models;
using ProdavnicaObuce.Settings;

namespace ProdavnicaObuce.UnitOfWorkConfig
{
    public class Repository<T> : IRepository<T> where T : Entitet
    {
        private DbSet<T> _dbSet;
        private ProdavnicaDbContext _context;

        public Repository(ProdavnicaDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IList<T>> GetAll()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            var user = await _dbSet.Where(t => t.Id == id).FirstOrDefaultAsync();
            return user;
        }

        public async Task Insert(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
