using Microsoft.EntityFrameworkCore;
using Stefanini.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Infrastructure.Repository
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly SteContext _context;
        protected readonly DbSet<TEntity> DbSet;

        public EFRepository(SteContext context)
        {
            _context = context;
            DbSet = context.Set<TEntity>();
        }

        public virtual async Task Create(TEntity entity)
        {
            await _context.AddAsync(entity);
            await SaveChangeAsync();
        }

        public virtual async Task Delete(TEntity entity)
        {
            _context.Remove(entity);
            await SaveChangeAsync();
        }
    
        public virtual async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetId(int Id)
        {
            return await DbSet.FindAsync(Id);
        }

        public virtual async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public virtual async Task Update(TEntity entity)
        {

            _context.Update(entity);
            await SaveChangeAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
