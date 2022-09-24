using VendaImoveis.Domain.Core;

namespace VendaImoveis.Domain.Entities.Enums
{
    public class PropertyType : Enumeration
    {
        public static PropertyType Residencial = new PropertyType(1, nameof(Residencial));
        public static PropertyType Comercial = new PropertyType(2, nameof(Comercial));
        public static PropertyType Industrial = new PropertyType(3, nameof(Industrial));
        public static PropertyType Client = new PropertyType(4, nameof(Client));

        public PropertyType(int id, string name) : base(id, name)
        {

        }
    }
}
