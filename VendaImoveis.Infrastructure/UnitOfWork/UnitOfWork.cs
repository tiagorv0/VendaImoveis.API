using VendaImoveis.Domain.Interfaces.Common;
using VendaImoveis.Infrastructure.Context;

namespace VendaImoveis.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
