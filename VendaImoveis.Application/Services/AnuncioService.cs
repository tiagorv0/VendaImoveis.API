using AutoMapper;
using FluentValidation;
using VendaImoveis.Application.Exceptions;
using VendaImoveis.Application.Interfaces;
using VendaImoveis.Application.Params.Params;
using VendaImoveis.Application.Params.Search;
using VendaImoveis.Application.Services.Common;
using VendaImoveis.Application.ViewModels.Anuncio;
using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Interfaces;
using VendaImoveis.Domain.Interfaces.Common;

namespace VendaImoveis.Application.Services
{
    public class AnuncioService :
        CrudService<Anuncio, RequestAnuncio, ResponseAnuncio, AnuncioParams, AnuncioSearch>,
        IAnuncioService
    {

        public AnuncioService(IAnuncioRepository repository, 
                                IMapper mapper, 
                                IUnitOfWork unitOfWork, 
                                IValidator<RequestAnuncio> validator,
                                IAuthService authService
        ) : base(repository, mapper, unitOfWork, validator, authService)
        {
        }

        public async override Task<ResponseAnuncio> CreateAsync(RequestAnuncio model)
        {
            var validation = await _validator.ValidateAsync(model);
            if (!validation.IsValid)
                throw new BadRequestException(validation);

            var created = await _repository.CreateAsync(_mapper.Map<Anuncio>(model));
            created.ImobiliariaId = _authService.Id;

            await _unitOfWork.CommitAsync();

            return _mapper.Map<ResponseAnuncio>(created);
        }
    }
}
