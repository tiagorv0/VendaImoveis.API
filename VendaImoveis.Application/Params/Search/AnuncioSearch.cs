namespace VendaImoveis.Application.Params.Search
{
    public class AnuncioSearch : SearchBase
    {
        public bool? Ativo { get; set; }
        public int? ImobiliariaId { get; set; }
        public int? PropriedadeId { get; set; }
    }
}
