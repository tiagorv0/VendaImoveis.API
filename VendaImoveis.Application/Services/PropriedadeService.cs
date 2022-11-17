using AutoMapper;
using FluentValidation;
using VendaImoveis.Application.Interfaces;
using VendaImoveis.Application.Params.Params;
using VendaImoveis.Application.Params.Search;
using VendaImoveis.Application.Services.Common;
using VendaImoveis.Application.ViewModels.Propriedade;
using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Interfaces;
using VendaImoveis.Domain.Interfaces.Common;

namespace VendaImoveis.Application.Services
{
    public class PropriedadeService :
        CrudService<Propriedade, RequestPropriedade, ResponsePropriedade, PropriedadeParams, PropriedadeSearch>,
        IPropriedadeService
    {
        public PropriedadeService(IPropriedadeRepository repository,
                                    IMapper mapper,
                                    IUnitOfWork unitOfWork,
                                    IValidator<RequestPropriedade> validator,
                                    IAuthService authService
        ) : base(repository, mapper, unitOfWork, validator, authService)
        {
        }


    }
}
