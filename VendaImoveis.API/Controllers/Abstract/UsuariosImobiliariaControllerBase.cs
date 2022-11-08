using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendaImoveis.Application.Services.Common.Interfaces;
using VendaImoveis.Domain.Core;
using VendaImoveis.Domain.Core.Params;

namespace VendaImoveis.API.Controllers.Abstract
{
    public abstract class UsuariosImobiliariaControllerBase<TEntity, TRequest, TResponse, TParams, TSearch> :
        CrudControllerBase<TEntity, TRequest, TResponse, TParams, TSearch>
        where TEntity : UsuariosImobiliaria
        where TRequest : class
        where TResponse : class
        where TParams : IParams
        where TSearch : ISearch
    {
        protected readonly new IUsuariosImobiliariaService<TEntity, TRequest, TResponse, TParams, TSearch> _service;
        public UsuariosImobiliariaControllerBase(
            IUsuariosImobiliariaService<TEntity, TRequest, TResponse, TParams, TSearch> service
        ) : base(service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet("GetOwnData")]
        public virtual async Task<IActionResult> GetOwnDataAsync()
        {
            var obj = await _service.GetOwnDataAsync();
            return Ok(obj);
        }
    }
}
