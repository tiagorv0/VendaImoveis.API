using LinqKit;
using System.Linq.Expressions;
using VendaImoveis.Domain.Entities;

namespace VendaImoveis.Application.Params.Params
{
    public class ImobiliariaParams : BaseParams<Imobiliaria>
    {
        public string? Nome { get; set; }
        public string? CNPJ { get; set; }

        public override Expression<Func<Imobiliaria, bool>> Filter()
        {
            var predicate = PredicateBuilder.New<Imobiliaria>();

            if (!string.IsNullOrEmpty(Nome))
                predicate = predicate.And(x => x.Nome.Contains(Nome));

            if (!string.IsNullOrEmpty(CNPJ))
                predicate = predicate.And(x => x.CNPJ.Contains(CNPJ));

            return predicate;
        }
    }
}
