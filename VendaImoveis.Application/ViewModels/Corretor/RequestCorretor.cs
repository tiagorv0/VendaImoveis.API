namespace VendaImoveis.Application.ViewModels.Corretor
{
    public class RequestCorretor : RequestUsuarioImobiliaria
    {
        public string CPF { get; set; }
        public int ImobiliariaId { get; set; }
    }
}
