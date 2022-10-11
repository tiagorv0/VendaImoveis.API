using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VendaImoveis.Application.ViewModels.Login;

namespace VendaImoveis.Application.Interfaces
{
    public interface ILoginService
    {
        Task<IEnumerable<Claim>> Login(LoginViewModel model);
    }
}
