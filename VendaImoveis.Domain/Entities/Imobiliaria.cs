using VendaImoveis.Domain.Core;

namespace VendaImoveis.Domain.Entities
{
    public class Imobiliaria : UsuariosImobiliaria
    {
        public string CNPJ { get; set; }
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual IEnumerable<Anuncio> Anuncios { get; set; }
        public virtual IEnumerable<Corretor> Corretores { get; set; }
    }
}
