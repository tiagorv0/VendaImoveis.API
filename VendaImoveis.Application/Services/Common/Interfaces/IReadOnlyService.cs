using VendaImoveis.Domain.Core;
using VendaImoveis.Domain.Core.Params;

namespace VendaImoveis.Application.Common.Interfaces
{
    public interface IReadOnlyService<TEntity, TRequest, TResponse, TParams, TSearch>
        where TEntity : Registro
        where TRequest : class
        where TResponse : class
        where TParams : IParams
        where TSearch : ISearch
    {
        Task<int> CountAsync(TParams @params);
        Task<TResponse> GetByIdAsync(int id);
        Task<IEnumerable<TResponse>> SearchAsync(TParams @params, IPaginavel paginavel);
        Task<IEnumerable<TResponse>> SearchAsync(ISearch search);
    }
}
