using VendaImoveis.Application.Interfaces.Common;
using VendaImoveis.Application.Interfaces.Storage;
using VendaImoveis.Application.Params.Params;
using VendaImoveis.Application.Params.Search;
using VendaImoveis.Application.ViewModels.Propriedade;
using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Interfaces.Common;

namespace VendaImoveis.Application.Interfaces
{
    public interface IPropriedadeService : IService,
        ICrudService<Propriedade, RequestPropriedade, ResponsePropriedade, PropriedadeParams, PropriedadeSearch>
    {
    }
}
