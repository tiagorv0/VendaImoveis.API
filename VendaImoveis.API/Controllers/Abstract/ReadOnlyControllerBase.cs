using Microsoft.AspNetCore.Mvc;
using VendaImoveis.API.Response;
using VendaImoveis.Application.Interfaces.Common;
using VendaImoveis.Domain.Core;
using VendaImoveis.Domain.Core.Params;

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
        public virtual async Task<IActionResult> GetAllAsync([FromQuery] TParams @params)
        {
            var obj = GetResult(
                await _service.GetAllAsync(@params),
                await _service.CountAsync(@params)
                );
            return Ok(obj);
        }

        [HttpGet("search")]
        public virtual async Task<IActionResult> SearchAsync([FromQuery] TSearch @search)
        {
            var obj = GetResult(
                await _service.SearchAsync(@search),
                await _service.CountAsync(@search)
                );
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var obj = await _service.GetByIdAsync(id);
            return Ok(obj);
        }

        private Result<T> GetResult<T>(T data, int? total = null) => new Result<T>(data, total);
    }
}
