using VendaImoveis.Application.ViewModels.Imobiliaria;
using VendaImoveis.Application.ViewModels.Propriedade;
using VendaImoveis.Domain.Core;

namespace VendaImoveis.Application.ViewModels.Anuncio
{
    public class ResponseAnuncio : Registro
    {
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public ResponseImobiliaria Imobiliaria { get; set; }
        public ResponsePropriedade Propriedade { get; set; }
    }
}
