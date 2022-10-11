using VendaImoveis.Domain.Core;
using VendaImoveis.Domain.Core.Params;

namespace VendaImoveis.Application.Common.Interfaces
{
    public interface ICrudService<TEntity, TRequest, TResponse, TParams> :
        IReadOnlyService<TEntity, TRequest, TResponse, TParams>
        where TEntity : Registro
        where TRequest : class
        where TResponse : class
        where TParams : IParams
    {
        Task<TResponse> CreateAsync(TRequest model);
        Task<TResponse> UpdateAsync(int id, TRequest model);
        Task RemoveAsync(int id);
    }
}
