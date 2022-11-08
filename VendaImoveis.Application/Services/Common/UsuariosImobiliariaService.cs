using VendaImoveis.Application.Services.Common.Interfaces;
using VendaImoveis.Domain.Core.Params;
using VendaImoveis.Domain.Core;
using VendaImoveis.Domain.Interfaces.Common;
using AutoMapper;
using FluentValidation;
using VendaImoveis.Application.Interfaces;

namespace VendaImoveis.Application.Services.Common
{
    public class UsuariosImobiliariaService<TEntity, TRequest, TResponse, TParams, TSearch> :
        CrudService<TEntity, TRequest, TResponse, TParams, TSearch>,
        IUsuariosImobiliariaService<TEntity, TRequest, TResponse, TParams, TSearch>
        where TEntity : UsuariosImobiliaria
        where TRequest : class
        where TResponse : class
        where TParams : IParams
        where TSearch : ISearch
    {
        protected readonly new IUsuariosImobiliariaRepository<TEntity> _repository;

        public UsuariosImobiliariaService(
            IUsuariosImobiliariaRepository<TEntity> repository, 
            IMapper mapper, 
            IUnitOfWork unitOfWork, 
            IValidator<TRequest> validator, 
            IAuthService authService
        ) : base(repository, mapper, unitOfWork, validator, authService)
        {
            _repository = repository;
        }

        public virtual async Task<TResponse> GetOwnDataAsync()
        {
            return _mapper.Map<TResponse>(await _repository.GetByIdAsync(_authService.Id));
        }
    }
}
