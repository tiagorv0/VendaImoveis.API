using VendaImoveis.Domain.Core;

namespace VendaImoveis.Domain.Entities.Enums
{
    public class UserRole : Enumeration
    {
        public static UserRole Imobiliaria = new UserRole(1, nameof(Imobiliaria));
        public static UserRole Corretor = new UserRole(2, nameof(Corretor));
        public static UserRole Comum = new UserRole(3, nameof(Comum));

        public UserRole(int id, string name) : base(id, name)
        {

        }
    }
}
