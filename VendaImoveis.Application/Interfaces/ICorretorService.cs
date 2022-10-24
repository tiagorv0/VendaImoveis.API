using VendaImoveis.Application.Common.Interfaces;
using VendaImoveis.Application.Params.Params;
using VendaImoveis.Application.Params.Search;
using VendaImoveis.Application.ViewModels.Corretor;
using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Interfaces.Common;

namespace VendaImoveis.Application.Interfaces
{
    public interface ICorretorService : IService,
        ICrudService<Corretor, RequestCorretor, ResponseCorretor, CorretorParams, CorretorSearch>
    {
    }
}
