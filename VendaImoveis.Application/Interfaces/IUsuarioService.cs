using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendaImoveis.Application.Common.Interfaces;
using VendaImoveis.Application.Params.Params;
using VendaImoveis.Application.Params.Search;
using VendaImoveis.Application.ViewModels.Usuario;
using VendaImoveis.Domain.Entities;

namespace VendaImoveis.Application.Interfaces
{
    public interface IUsuarioService : 
        ICrudService<Usuario, RequestUsuario, ResponseUsuario, UsuarioParams, UsuarioSearch>
    {
    }
}
