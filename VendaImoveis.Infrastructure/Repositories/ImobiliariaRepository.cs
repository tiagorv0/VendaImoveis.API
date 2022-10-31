using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Interfaces;
using VendaImoveis.Infrastructure.Context;
using VendaImoveis.Infrastructure.Repositories.Common;
using VendaImoveis.Infrastructure.Utils;

namespace VendaImoveis.Infrastructure.Repositories
{
    public class ImobiliariaRepository : UsuariosImobiliariaRepository<Imobiliaria>, IImobiliariaRepository
    {
        public ImobiliariaRepository(ApplicationContext context):base(context)
        {

        }

        
    }
}
