using LinqKit;
using System.Linq.Expressions;
using VendaImoveis.Domain.Entities;

namespace VendaImoveis.Application.Params.Params
{
    public class CorretorParams : BaseParams<Corretor>
    {
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public int? ImobiliariaId { get; set; }

        public override Expression<Func<Corretor, bool>> Filter()
        {
            var predicate = PredicateBuilder.New<Corretor>();

            if (string.IsNullOrEmpty(Nome))
                predicate = predicate.And(x => x.Nome.Equals(Nome));

            if (string.IsNullOrEmpty(CPF))
                predicate = predicate.And(x => x.CPF.Equals(CPF));

            if (ImobiliariaId.HasValue)
                predicate = predicate.And(x => x.ImobiliariaId == ImobiliariaId);

            return predicate;
        }
    }
}
