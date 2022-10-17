using AutoMapper;
using FluentValidation;
using VendaImoveis.Application.Interfaces;
using VendaImoveis.Application.Params.Params;
using VendaImoveis.Application.Params.Search;
using VendaImoveis.Application.Services.Common;
using VendaImoveis.Application.ViewModels.Usuario;
using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Interfaces.Common;

namespace VendaImoveis.Application.Services
{
    public class UsuarioService :
        CrudService<Usuario, RequestUsuario, ResponseUsuario, UsuarioParams, UsuarioSearch>,
        IUsuarioService
    {
        public UsuarioService(IBaseRepository<Usuario> repository, IMapper mapper, IUnitOfWork unitOfWork, IValidator<RequestUsuario> validator) : base(repository, mapper, unitOfWork, validator)
        {
        }
    }
}
