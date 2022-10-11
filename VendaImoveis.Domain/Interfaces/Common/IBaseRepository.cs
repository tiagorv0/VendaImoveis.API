using VendaImoveis.Domain.Core;

namespace VendaImoveis.Domain.Interfaces.Common
{
    public interface IBaseRepository<TEntity> : IBaseReadOnlyRepository<TEntity>
        where TEntity : Registro
    {
        Task<TEntity> CreateAsync(TEntity model);
        Task<TEntity> UpdateAsync(TEntity model);
        Task DeleteAsync(int id);

    }
}
