using AspNetCore.IQueryable.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VendaImoveis.Domain.Core;
using VendaImoveis.Domain.Core.Common;
using VendaImoveis.Domain.Core.Params;
using VendaImoveis.Domain.Interfaces.Common;
using VendaImoveis.Infrastructure.Context;

namespace VendaImoveis.Infrastructure.Repositories.Common
{
    public class BaseReadOnlyRepository<TEntity> : IBaseReadOnlyRepository<TEntity> where TEntity : Registro
    {
        protected readonly DbSet<TEntity> _dbSet;

        public BaseReadOnlyRepository(ApplicationContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> filter = null,
            IPaginavel pagination = null)
        {
            return await GetQueryable(filter, pagination: pagination ?? new Pagination()).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(IParams @params)
        {
            return await GetQueryable(@params).ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await GetQueryable(e => e.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public virtual async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await GetQueryable(filter).FirstOrDefaultAsync();
        }

        public virtual async Task<int> CountAsync(IFiltrable<TEntity> filter = null)
        {
            return await CountAsync(filter?.Filter());
        }

        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await GetQueryable(filter).CountAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> SearchAsync(ISearch search)
        {
            return await _dbSet.AsQueryable().Apply(search).ToListAsync();
        }

        public virtual async Task<bool> ExistAsync(int id)
        {
            return await ExistAsync(x => x.Id.Equals(id));
        }

        public virtual async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> filter)
        {
            ArgumentNullException.ThrowIfNull(filter);
            return await GetQueryable(filter).AnyAsync();
        }

        protected virtual IQueryable<TEntity> GetQueryable(IParams @params)
        {
            var filter = @params as IFiltrable<TEntity>;
            var pagination = @params as IPaginavel;
            return GetQueryable(filter?.Filter(), pagination);
        }

        protected virtual IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> filter = null, IPaginavel pagination = null)
        {
            var query = _dbSet.AsQueryable();

            if (filter is not null) query = query.Where(filter);

            if (pagination is not null)
            {
                query = query.Skip(pagination.Skip.GetValueOrDefault());
                if (pagination.Take.HasValue) query = query.Take(pagination.Take.Value);
            }

            return query;
        }
    }
}
