using VendaImoveis.Application.Common.Interfaces;
using VendaImoveis.Application.Params.Params;
using VendaImoveis.Application.Params.Search;
using VendaImoveis.Application.ViewModels.Usuario;
using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Interfaces.Common;

namespace VendaImoveis.Application.Interfaces
{
    public interface IUsuarioService : IService,
        ICrudService<Usuario, RequestUsuario, ResponseUsuario, UsuarioParams, UsuarioSearch>
    {
    }
}
