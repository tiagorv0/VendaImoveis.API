using VendaImoveis.Domain.Core;

namespace VendaImoveis.Domain.Entities.Enums
{
    public class UserRole : Enumeration
    {
        public static UserRole Admin = new UserRole(1, nameof(Admin));
        public static UserRole Empresa = new UserRole(2, nameof(Empresa));
        public static UserRole Corretor = new UserRole(3, nameof(Corretor));
        public static UserRole Comum = new UserRole(4, nameof(Comum));

        public UserRole(int id, string name) : base(id, name)
        {

        }
    }
}
