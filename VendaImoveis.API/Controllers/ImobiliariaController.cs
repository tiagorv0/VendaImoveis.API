using VendaImoveis.API.Controllers.Abstract;
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

    }
}
