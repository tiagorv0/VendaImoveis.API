using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VendaImoveis.Domain.Core;
using VendaImoveis.Domain.Interfaces;
using VendaImoveis.Infrastructure.Context;
using VendaImoveis.Domain.Core.Params;

namespace VendaImoveis.Infrastructure.Repositories
{
    public class BaseReadOnlyRepository<TEntity> : IBaseReadOnlyRepository<TEntity> where TEntity : Registro
    {
        protected readonly DbSet<TEntity> _dbSet;

        public BaseReadOnlyRepository(ApplicationContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, 
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, 
            bool asNoTracking = false, IPaginavel paginable = null)
        {
            var query = _dbSet.AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            if (include != null)
                query = include(query);

            if (asNoTracking)
                query = query.AsNoTracking();

            if (paginable != null)
            {
                query = query.Skip(paginable.Skip.GetValueOrDefault());
                if (paginable.Take.HasValue) query = query.Take(paginable.Take.Value);
            }

            return await query.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            var query = _dbSet.AsQueryable();

            if (include != null)
                query = include(query);

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }
        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null, bool asNoTracking = true)
        {
            var count = await GetAllAsync(filter, asNoTracking: asNoTracking);
            return count.Count();
        }
    }
}
