using Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Library.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly LibraryDbContext context;
        private readonly DbSet<T> dbSet;

        public Repository(LibraryDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            
            await context.SaveChangesAsync(); 
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await dbSet.AddRangeAsync(entities);

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
           var entities = await dbSet.Where(predicate).ToListAsync();
            return entities;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            dbSet.Remove(entity);

            await context.SaveChangesAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);

            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            dbSet.Update(entity);

            await context.SaveChangesAsync();
        }
    }
}
