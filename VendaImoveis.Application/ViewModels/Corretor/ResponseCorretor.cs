using VendaImoveis.Application.ViewModels.Common;
using VendaImoveis.Application.ViewModels.Imobiliaria;
using VendaImoveis.Application.ViewModels.Venda;

namespace VendaImoveis.Application.ViewModels.Corretor
{
    public class ResponseCorretor : ResponseUsuariosImobiliaria
    {
        public string CPF { get; set; }
        public ResponseImobiliaria Imobiliaria { get; set; }
        public IEnumerable<ResponseVenda> Vendas { get; set; } = new List<ResponseVenda>();
    }
}
