using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using VendaImoveis.Domain.Core;

namespace VendaImoveis.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : Registro
    {
        Task<TEntity> CreateAsync(TEntity model);
        Task<TEntity> UpdateAsync(TEntity model);
        Task DeleteAsync(int id);
        
    }
}
