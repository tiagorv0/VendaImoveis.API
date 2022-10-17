using VendaImoveis.Application.ViewModels.Anuncio;
using VendaImoveis.Application.ViewModels.Corretor;
using VendaImoveis.Domain.Core;

namespace VendaImoveis.Application.ViewModels.Venda
{
    public class ResponseVenda : Registro
    {
        public ResponseAnuncio Anuncio { get; set; }
        public ResponseCorretor Corretor { get; set; }
    }
}
