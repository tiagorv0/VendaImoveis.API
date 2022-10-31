using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendaImoveis.API.Controllers.Abstract;
using VendaImoveis.Application.Constants;
using VendaImoveis.Application.Interfaces;
using VendaImoveis.Application.Params.Params;
using VendaImoveis.Application.Params.Search;
using VendaImoveis.Application.ViewModels.Anuncio;
using VendaImoveis.Domain.Entities;

namespace VendaImoveis.API.Controllers
{
    public class AnuncioController :
        CrudControllerBase<Anuncio, RequestAnuncio, ResponseAnuncio, AnuncioParams, AnuncioSearch>
    {
        public AnuncioController(IAnuncioService service) : base(service)
        {
        }

        [Authorize(Roles = Roles.Imobiliaria)]
        public override Task<ResponseAnuncio> CreateAsync([FromBody] RequestAnuncio request)
        {
            return base.CreateAsync(request);
        }

        [Authorize(Roles = Roles.Imobiliaria)]
        public override Task<ResponseAnuncio> UpdateAsync([FromRoute] int id, [FromBody] RequestAnuncio request)
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
