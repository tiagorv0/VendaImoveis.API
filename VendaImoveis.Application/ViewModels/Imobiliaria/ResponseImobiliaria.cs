using VendaImoveis.Application.ViewModels.Anuncio;
using VendaImoveis.Application.ViewModels.Corretor;
using VendaImoveis.Application.ViewModels.Endereco;
using VendaImoveis.Domain.Core;

namespace VendaImoveis.Application.ViewModels.Imobiliaria
{
    public class ResponseImobiliaria : ResponseUsuarioImobiliaria
    {
        public string CNPJ { get; set; }
        public EnderecoViewModel Endereco { get; set; }
        public IEnumerable<ResponseAnuncio> Anuncios { get; set; } = new List<ResponseAnuncio>();
        public IEnumerable<ResponseCorretor> Corretores { get; set; } = new List<ResponseCorretor>();
    }
}
