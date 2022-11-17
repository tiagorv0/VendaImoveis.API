using VendaImoveis.Application.Interfaces.Common;
using VendaImoveis.Application.Params.Params;
using VendaImoveis.Application.Params.Search;
using VendaImoveis.Application.ViewModels.Anuncio;
using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Interfaces.Common;

namespace VendaImoveis.Application.Interfaces
{
    public interface IAnuncioService : IService,
        ICrudService<Anuncio, RequestAnuncio, ResponseAnuncio, AnuncioParams, AnuncioSearch>
    {
    }
}
