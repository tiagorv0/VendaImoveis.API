namespace VendaImoveis.Domain.Core.Params
{
    public interface IPaginavel
    {
        int? Skip { get; set; }
        int? Take { get; set; }
    }
}
