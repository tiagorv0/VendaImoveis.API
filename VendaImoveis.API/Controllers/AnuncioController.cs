using VendaImoveis.API.Controllers.Abstract;
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
    }
}
