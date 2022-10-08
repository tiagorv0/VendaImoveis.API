using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Interfaces;
using VendaImoveis.Infrastructure.Context;
using VendaImoveis.Infrastructure.Repositories.Common;

namespace VendaImoveis.Infrastructure.Repositories
{
    public class ImobiliariaRepository : BaseRepository<Imobiliaria>, IImobiliariaRepository
    {
        public ImobiliariaRepository(ApplicationContext context):base(context)
        {

        }
    }
}
