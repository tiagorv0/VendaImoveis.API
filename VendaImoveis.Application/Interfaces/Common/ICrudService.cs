using VendaImoveis.Domain.Core;
using VendaImoveis.Domain.Core.Params;

namespace VendaImoveis.Application.Interfaces.Common
{
    public interface ICrudService<TEntity, TRequest, TResponse, TParams, TSearch> :
        IReadOnlyService<TEntity, TRequest, TResponse, TParams, TSearch>
        where TEntity : Registro
        where TRequest : class
        where TResponse : class
        where TParams : IParams
        where TSearch : ISearch
    {
        Task<TResponse> CreateAsync(TRequest model);
        Task<TResponse> UpdateAsync(int id, TRequest model);
        Task RemoveAsync(int id);
    }
}
