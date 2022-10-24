using Microsoft.AspNetCore.Mvc;
using VendaImoveis.Application.Common.Interfaces;
using VendaImoveis.Domain.Core.Params;
using VendaImoveis.Domain.Core;

namespace VendaImoveis.API.Controllers.Abstract
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public abstract class ReadOnlyControllerBase<TEntity, TRequest, TResponse, TParams, TSearch> : ControllerBase
        where TEntity : Registro
        where TRequest : class
        where TResponse : class
        where TParams : IParams
        where TSearch : ISearch
    {
        protected readonly IReadOnlyService<TEntity, TRequest, TResponse, TParams, TSearch> _service;

        protected ReadOnlyControllerBase(
            IReadOnlyService<TEntity, TRequest, TResponse, TParams, TSearch> service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual async Task<IEnumerable<TResponse>> GetAllAsync([FromQuery] TParams @params)
        {
            return await _service.GetAllAsync(@params);
        }

        [HttpGet("search")]
        public virtual async Task<IEnumerable<TResponse>> SearchAsync([FromQuery] TSearch @search)
        {
            return await _service.SearchAsync(@search);
        }

        [HttpGet("{id}")]
        public virtual async Task<TResponse> GetByIdAsync([FromRoute] int id)
        {
            return await _service.GetByIdAsync(id);
        }
    }
}
