using System.Linq.Expressions;
using VendaImoveis.Domain.Core;
using VendaImoveis.Domain.Core.Params;

namespace VendaImoveis.Domain.Interfaces.Common
{
    public interface IBaseReadOnlyRepository<TEntity> where TEntity : Registro
    {
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, IPaginavel paginable = null);
        Task<IEnumerable<TEntity>> GetAllAsync(IParams @params);
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<IEnumerable<TEntity>> SearchAsync(ISearch search);
        Task<bool> ExistAsync(int id);
        Task<bool> ExistAsync(Expression<Func<TEntity, bool>> filter);
    }
}
