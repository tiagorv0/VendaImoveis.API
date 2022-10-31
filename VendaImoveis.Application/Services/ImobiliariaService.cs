using AutoMapper;
using FluentValidation;
using VendaImoveis.Application.Interfaces;
using VendaImoveis.Application.Params.Params;
using VendaImoveis.Application.Params.Search;
using VendaImoveis.Application.Services.Common;
using VendaImoveis.Application.ViewModels.Imobiliaria;
using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Interfaces;
using VendaImoveis.Domain.Interfaces.Common;

namespace VendaImoveis.Application.Services
{
    public class ImobiliariaService :
        CrudService<Imobiliaria, RequestImobiliaria, ResponseImobiliaria, ImobiliariaParams, ImobiliariaSearch>,
        IImobiliariaService
    {
        public ImobiliariaService(IImobiliariaRepository repository, 
            IMapper mapper, 
            IUnitOfWork unitOfWork, 
            IValidator<RequestImobiliaria> validator
        ) : base(repository, mapper, unitOfWork, validator)
        {
        }
    }
}
