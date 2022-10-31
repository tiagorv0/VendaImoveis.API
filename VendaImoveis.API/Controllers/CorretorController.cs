using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendaImoveis.API.Controllers.Abstract;
using VendaImoveis.Application.Constants;
using VendaImoveis.Application.Interfaces;
using VendaImoveis.Application.Params.Params;
using VendaImoveis.Application.Params.Search;
using VendaImoveis.Application.ViewModels.Corretor;
using VendaImoveis.Domain.Entities;

namespace VendaImoveis.API.Controllers
{
    public class CorretorController :
        CrudControllerBase<Corretor, RequestCorretor, ResponseCorretor, CorretorParams, CorretorSearch>
    {
        public CorretorController(ICorretorService service) : base(service)
        {
        }

        [Authorize(Roles = Roles.Corretor)]
        public override Task<ResponseCorretor> UpdateAsync([FromRoute] int id, [FromBody] RequestCorretor request)
        {
            return base.UpdateAsync(id, request);
        }

        [Authorize(Roles = Roles.Corretor)]
        public override Task DeleteAsync([FromRoute] int id)
        {
            return base.DeleteAsync(id);
        }
    }
}
