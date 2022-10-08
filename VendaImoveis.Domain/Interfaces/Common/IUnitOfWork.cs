namespace VendaImoveis.Domain.Interfaces.Common
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}
