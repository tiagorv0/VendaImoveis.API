using AutoMapper;
using VendaImoveis.Application.Exceptions;
using VendaImoveis.Application.Interfaces;
using VendaImoveis.Application.Interfaces.Common;
using VendaImoveis.Domain.Core;
using VendaImoveis.Domain.Core.Params;
using VendaImoveis.Domain.Interfaces.Common;

namespace VendaImoveis.Application.Services.Common
{
    public class ReadOnlyService<TEntity, TRequest, TResponse, TParams, TSearch> :
        IReadOnlyService<TEntity, TRequest, TResponse, TParams, TSearch>
        where TEntity : Registro
        where TRequest : class
        where TResponse : class
        where TParams : IParams
        where TSearch : ISearch
    {
        protected readonly IBaseReadOnlyRepository<TEntity> _repository;
        protected readonly IMapper _mapper;
        protected readonly IAuthService _authService;

        public ReadOnlyService(IBaseReadOnlyRepository<TEntity> repository, 
                                IMapper mapper,
                                IAuthService authService)
        {
            _repository = repository;
            _mapper = mapper;
            _authService = authService;
        }

        public virtual async Task<int> CountAsync(TParams @params)
        {
            return await _repository.CountAsync(@params as IFiltrable<TEntity>);
        }

        public virtual async Task<int> CountAsync(TSearch @search)
        {
            return await _repository.CountAsync(@search as IFiltrable<TEntity>);
        }

        public virtual async Task<TResponse> GetByIdAsync(int id)
        {
            var exist = await _repository.GetByIdAsync(id);
            if (exist is null)
                throw new NotFoundException();

            return _mapper.Map<TResponse>(exist);
        }

        public virtual async Task<IEnumerable<TResponse>> GetAllAsync(TParams @params)
        {
            return _mapper.Map<IEnumerable<TResponse>>(await _repository.GetAllAsync(@params));
        }

        public virtual async Task<IEnumerable<TResponse>> SearchAsync(TSearch @search)
        {
            return _mapper.Map<IEnumerable<TResponse>>(await _repository.SearchAsync(search));
        }

        public virtual async Task<TResponse> GetOwnDataAsync()
        {
            return _mapper.Map<TResponse>(await _repository.GetByIdAsync(_authService.Id));
        }
    }
}
