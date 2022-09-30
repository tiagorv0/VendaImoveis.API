using VendaImoveis.Domain.Core;

namespace VendaImoveis.Domain.Entities
{
    public class Imobiliaria : Registro
    {
        public string CNPJ { get; set; }
        public string Creci { get; set; }
        public Endereco Endereco { get; set; }
        public virtual IEnumerable<ImobiliariaPropriedade> PropriedadesDaImobiliaria { get; set; }
        public virtual IEnumerable<Corretor> Corretores { get; set; }
    }
}
