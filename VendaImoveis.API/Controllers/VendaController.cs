using VendaImoveis.API.Controllers.Abstract;
using VendaImoveis.Application.Interfaces;
using VendaImoveis.Application.Params.Params;
using VendaImoveis.Application.Params.Search;
using VendaImoveis.Application.ViewModels.Venda;
using VendaImoveis.Domain.Entities;

namespace VendaImoveis.API.Controllers
{
    public class VendaController :
        CrudControllerBase<Venda, RequestVenda, ResponseVenda, VendaParams, VendaSearch>
    {
        public VendaController(IVendaService service) : base(service)
        {
        }
    }
}
