using VendaImoveis.Application.ViewModels.Imobiliaria;
using VendaImoveis.Application.ViewModels.Venda;
using VendaImoveis.Domain.Core;

namespace VendaImoveis.Application.ViewModels.Corretor
{
    public class ResponseCorretor : ResponseUsuarioImobiliaria
    {
        public string CPF { get; set; }
        public ResponseImobiliaria Imobiliaria { get; set; }
        public IEnumerable<ResponseVenda> Vendas { get; set; } = new List<ResponseVenda>();
    }
}
