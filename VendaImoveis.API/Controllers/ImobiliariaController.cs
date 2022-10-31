using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendaImoveis.API.Controllers.Abstract;
using VendaImoveis.Application.Constants;
using VendaImoveis.Application.Interfaces;
using VendaImoveis.Application.Params.Params;
using VendaImoveis.Application.Params.Search;
using VendaImoveis.Application.ViewModels.Imobiliaria;
using VendaImoveis.Domain.Entities;

namespace VendaImoveis.API.Controllers
{
    public class ImobiliariaController :
        CrudControllerBase<Imobiliaria, RequestImobiliaria, ResponseImobiliaria, ImobiliariaParams, ImobiliariaSearch>
    {
        public ImobiliariaController(
            IImobiliariaService service
        ) : base(service)
        {
        }

        [Authorize(Roles = Roles.Imobiliaria)]
        public override Task<ResponseImobiliaria> UpdateAsync([FromRoute] int id, [FromBody] RequestImobiliaria request)
        {
            return base.UpdateAsync(id, request);
        }

        [Authorize(Roles = Roles.Imobiliaria)]
        public override Task DeleteAsync([FromRoute] int id)
        {
            return base.DeleteAsync(id);
        }
    }
}
