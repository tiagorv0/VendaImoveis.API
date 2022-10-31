using AutoMapper;
using FluentValidation;
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
            IValidator<RequestAnuncio> validator
        ) : base(repository, mapper, unitOfWork, validator)
        {
        }
    }
}
