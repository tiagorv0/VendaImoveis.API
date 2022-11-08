using VendaImoveis.Application.Params.Params;
using VendaImoveis.Application.Params.Search;
using VendaImoveis.Application.Services.Common.Interfaces;
using VendaImoveis.Application.ViewModels.Imobiliaria;
using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Interfaces.Common;

namespace VendaImoveis.Application.Interfaces
{
    public interface IImobiliariaService : IService,
        IUsuariosImobiliariaService<Imobiliaria, RequestImobiliaria, ResponseImobiliaria, ImobiliariaParams, ImobiliariaSearch>
    {
    }
}
