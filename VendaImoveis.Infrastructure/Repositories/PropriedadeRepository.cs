using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Interfaces;
using VendaImoveis.Infrastructure.Context;
using VendaImoveis.Infrastructure.Repositories.Common;

namespace VendaImoveis.Infrastructure.Repositories
{
    public class PropriedadeRepository : BaseRepository<Propriedade>, IPropriedadeRepository
    {
        public PropriedadeRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
