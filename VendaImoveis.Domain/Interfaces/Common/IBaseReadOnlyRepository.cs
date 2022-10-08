using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using VendaImoveis.Domain.Core;
using VendaImoveis.Domain.Core.Params;

namespace VendaImoveis.Domain.Interfaces.Common
{
    public interface IBaseReadOnlyRepository<TEntity> where TEntity : Registro
    {
        Task<TEntity> GetByIdAsync(int id,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null,
                                         Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool asNoTracking = false, IPaginavel paginable = null);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null, bool asNoTracking = true);
    }
}
