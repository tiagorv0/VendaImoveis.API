using AutoMapper;
using FluentValidation;
using VendaImoveis.Application.Interfaces;
using VendaImoveis.Application.Params.Params;
using VendaImoveis.Application.Params.Search;
using VendaImoveis.Application.Services.Common;
using VendaImoveis.Application.ViewModels.Corretor;
using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Interfaces;
using VendaImoveis.Domain.Interfaces.Common;

namespace VendaImoveis.Application.Services
{
    public class CorretorService :
        UsuariosImobiliariaService<Corretor, RequestCorretor, ResponseCorretor, CorretorParams, CorretorSearch>,
        ICorretorService
    {
        public CorretorService(ICorretorRepository repository, 
                                IMapper mapper, IUnitOfWork unitOfWork, 
                                IValidator<RequestCorretor> validator, 
                                IAuthService authService
        ) : base(repository, mapper, unitOfWork, validator, authService)
        {
        }

        
    }
}
