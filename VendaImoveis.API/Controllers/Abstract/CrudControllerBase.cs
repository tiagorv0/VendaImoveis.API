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
        public virtual async Task<IActionResult> CreateAsync([FromBody] TRequest request)
        {
            var obj = await _service.CreateAsync(request);
            return Ok(obj);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] TRequest request)
        {
            var obj = await _service.UpdateAsync(id, request);
            return Ok(obj);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await _service.RemoveAsync(id);
            return Ok();
        }
    }
}
