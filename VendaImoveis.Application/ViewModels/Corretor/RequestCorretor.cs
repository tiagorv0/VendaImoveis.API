namespace VendaImoveis.Application.ViewModels.Corretor
{
    public class RequestCorretor : RequestUsuariosImobiliaria
    {
        public string CPF { get; set; }
        public int ImobiliariaId { get; set; }
    }
}
