using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendaImoveis.Application.Common.Interfaces;
using VendaImoveis.Application.Params.Params;
using VendaImoveis.Application.Params.Search;
using VendaImoveis.Application.ViewModels.Anuncio;
using VendaImoveis.Domain.Entities;

namespace VendaImoveis.Application.Interfaces
{
    public interface IAnuncioService :
        ICrudService<Anuncio, RequestAnuncio, ResponseAnuncio, AnuncioParams, AnuncioSearch>
    {
    }
}
