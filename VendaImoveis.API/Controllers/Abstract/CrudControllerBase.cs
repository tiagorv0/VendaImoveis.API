using Microsoft.AspNetCore.Mvc;
using VendaImoveis.Domain.Core.Params;
using VendaImoveis.Domain.Core;
using VendaImoveis.Application.Common.Interfaces;

namespace VendaImoveis.API.Controllers.Abstract
{
    
    public abstract class CrudControllerBase<TEntity, TRequest, TResponse, TParams, TSearch> : 
        ReadOnlyControllerBase<TEntity, TRequest, TResponse, TParams, TSearch>
        where TEntity : Registro
        where TRequest : class
        where TResponse : class
        where TParams : IParams
        where TSearch : ISearch
    {
        protected readonly new ICrudService<TEntity, TRequest, TResponse, TParams, TSearch> _service;

        protected CrudControllerBase(
            ICrudService<TEntity, TRequest, TResponse, TParams, TSearch> service
        ) : base(service)
        {
            _service = service;
        }

        [HttpPost]
        public virtual async Task<TResponse> CreateAsync([FromBody] TRequest request)
        {
            return await _service.CreateAsync(request);
        }

        [HttpPut("{id}")]
        public virtual async Task<TResponse> UpdateAsync([FromRoute] int id, [FromBody] TRequest request)
        {
            return await _service.UpdateAsync(id, request);
        }

        [HttpDelete("{id}")]
        public virtual async Task DeleteAsync([FromRoute] int id)
        {
            await _service.RemoveAsync(id);
        }
    }
}
