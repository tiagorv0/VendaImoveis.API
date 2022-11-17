using VendaImoveis.Application.Interfaces.Common;
using VendaImoveis.Application.Params.Params;
using VendaImoveis.Application.Params.Search;
using VendaImoveis.Application.ViewModels.Corretor;
using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Interfaces.Common;

namespace VendaImoveis.Application.Interfaces
{
    public interface ICorretorService : IService,
        IUsuariosImobiliariaService<Corretor, RequestCorretor, ResponseCorretor, CorretorParams, CorretorSearch>
    {
    }
}
