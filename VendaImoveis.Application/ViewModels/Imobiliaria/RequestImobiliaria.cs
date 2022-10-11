using VendaImoveis.Application.ViewModels.Endereco;

namespace VendaImoveis.Application.ViewModels.Imobiliaria
{
    public class RequestImobiliaria : RequestUsuarioImobiliaria
    {
        public string CNPJ { get; set; }
        public EnderecoViewModel Endereco { get; set; }
    }
}
