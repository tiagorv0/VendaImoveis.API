using AutoMapper;
using FluentValidation;
using VendaImoveis.Application.Common.Interfaces;
using VendaImoveis.Application.Exceptions;
using VendaImoveis.Domain.Core;
using VendaImoveis.Domain.Core.Params;
using VendaImoveis.Domain.Interfaces.Common;

namespace VendaImoveis.Application.Services.Common
{
    public class CrudService<TEntity, TRequest, TResponse, TParams> :
        ReadOnlyService<TEntity, TRequest, TResponse, TParams>,
        ICrudService<TEntity, TRequest, TResponse, TParams>
        where TEntity : Registro
        where TRequest : class
        where TResponse : class
        where TParams : IParams
    {
        protected readonly new IBaseRepository<TEntity> _repository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IValidator<TRequest> _validator;

        public CrudService(IBaseRepository<TEntity> repository, 
                           IMapper mapper, 
                           IUnitOfWork unitOfWork, 
                           IValidator<TRequest> validator)
           : base(repository, mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public virtual async Task<TResponse> CreateAsync(TRequest model)
        {
            var validation = await _validator.ValidateAsync(model);
            if (!validation.IsValid)
                throw new BadRequestException(validation);

            var created = await _repository.CreateAsync(_mapper.Map<TEntity>(model));
            await _unitOfWork.CommitAsync();

            return _mapper.Map<TResponse>(created);
        }

        public virtual async Task<TResponse> UpdateAsync(int id, TRequest model)
        {
            var exist = await _repository.GetByIdAsync(id);
            if (exist is null)
                throw new NotFoundException();

            var validation = await _validator.ValidateAsync(model);
            if (!validation.IsValid)
                throw new BadRequestException(validation);

            _mapper.Map<TRequest, TEntity>(model, exist);

            var updated = await _repository.UpdateAsync(exist);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<TResponse>(updated);
        }

        public virtual async Task RemoveAsync(int id)
        {
            var exist = await _repository.GetByIdAsync(id);
            if (exist is null)
                throw new NotFoundException();

            await _repository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
        }
    }
}
