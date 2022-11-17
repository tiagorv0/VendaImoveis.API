using AutoMapper;
using FluentValidation;
using VendaImoveis.Application.Exceptions;
using VendaImoveis.Application.Interfaces;
using VendaImoveis.Application.Params.Params;
using VendaImoveis.Application.Params.Search;
using VendaImoveis.Application.Services.Common;
using VendaImoveis.Application.ViewModels.Venda;
using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Interfaces;
using VendaImoveis.Domain.Interfaces.Common;

namespace VendaImoveis.Application.Services
{
    public class VendaService :
        CrudService<Venda, RequestVenda, ResponseVenda, VendaParams, VendaSearch>,
        IVendaService
    {
        private readonly IAnuncioRepository _anuncioRepository;

        public VendaService(IVendaRepository repository,
                            IMapper mapper,
                            IUnitOfWork unitOfWork,
                            IValidator<RequestVenda> validator,
                            IAuthService authService,
                            IAnuncioRepository anuncioRepository) : base(repository, mapper, unitOfWork, validator, authService)
        {
            _anuncioRepository = anuncioRepository;
        }

        public async override Task<ResponseVenda> CreateAsync(RequestVenda model)
        {
            var exist = await _anuncioRepository.GetByIdAsync(model.AnuncioId);
            if (exist is null)
                throw new NotFoundException();

            exist.Ativo = false;
            exist.Propriedade.FoiVendida = true;

            var created = await _repository.CreateAsync(_mapper.Map<Venda>(model));
            await _unitOfWork.CommitAsync();

            return _mapper.Map<ResponseVenda>(created);
        }
    }
}
