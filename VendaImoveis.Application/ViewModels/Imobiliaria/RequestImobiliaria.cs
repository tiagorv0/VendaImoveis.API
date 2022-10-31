using VendaImoveis.Application.ViewModels.Common;
using VendaImoveis.Application.ViewModels.Endereco;

namespace VendaImoveis.Application.ViewModels.Imobiliaria
{
    public class RequestImobiliaria : RequestUsuariosImobiliaria
    {
        public string CNPJ { get; set; }
        public EnderecoViewModel Endereco { get; set; }
    }
}
