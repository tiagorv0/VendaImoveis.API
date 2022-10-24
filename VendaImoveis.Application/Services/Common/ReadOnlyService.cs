﻿using AutoMapper;
using VendaImoveis.Application.Common.Interfaces;
using VendaImoveis.Application.Exceptions;
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

        public ReadOnlyService(IBaseReadOnlyRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<int> CountAsync(TParams @params)
        {
            var filter = @params as IFiltrable<TEntity>;
            return await _repository.CountAsync(filter.Filter());
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

        public virtual async Task<IEnumerable<TResponse>> SearchAsync(ISearch search)
        {
            return _mapper.Map<IEnumerable<TResponse>>(await _repository.SearchAsync(search));
        }
    }
}
