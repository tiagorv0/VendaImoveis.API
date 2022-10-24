using VendaImoveis.Application.Common.Interfaces;
using VendaImoveis.Application.Params.Params;
using VendaImoveis.Application.Params.Search;
using VendaImoveis.Application.ViewModels.Venda;
using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Interfaces.Common;

namespace VendaImoveis.Application.Interfaces
{
    public interface IVendaService : IService,
        ICrudService<Venda, RequestVenda, ResponseVenda, VendaParams, VendaSearch>
    {
    }
}
