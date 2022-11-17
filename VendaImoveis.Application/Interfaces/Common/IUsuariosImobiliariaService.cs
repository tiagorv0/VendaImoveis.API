using VendaImoveis.Domain.Core.Params;
using VendaImoveis.Domain.Core;

namespace VendaImoveis.Application.Interfaces.Common
{
    public interface IUsuariosImobiliariaService<TEntity, TRequest, TResponse, TParams, TSearch> :
        ICrudService<TEntity, TRequest, TResponse, TParams, TSearch>
        where TEntity : UsuariosImobiliaria
        where TRequest : class
        where TResponse : class
        where TParams : IParams
        where TSearch : ISearch
    {
        Task<TResponse> GetOwnDataAsync();
    }
}
