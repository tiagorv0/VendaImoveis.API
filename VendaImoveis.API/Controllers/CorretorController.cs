using VendaImoveis.API.Controllers.Abstract;
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
    }
}
