using VendaImoveis.Application.Common.Interfaces;
using VendaImoveis.Application.Params.Params;
using VendaImoveis.Application.Params.Search;
using VendaImoveis.Application.ViewModels.Corretor;
using VendaImoveis.Domain.Entities;

namespace VendaImoveis.Application.Interfaces
{
    public interface ICorretorService :
        ICrudService<Corretor, RequestCorretor, ResponseCorretor, CorretorParams, CorretorSearch>
    {
    }
}
