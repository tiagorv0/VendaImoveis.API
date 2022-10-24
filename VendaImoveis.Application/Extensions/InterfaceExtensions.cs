namespace VendaImoveis.Application.Extensions
{
    public static class InterfaceExtensions
    {
        public static IEnumerable<Type> GetDirectInterfaces(this Type type)
        {
            var allInterfaces = new List<Type>();
            var parentInterfaces = new List<Type>();

            foreach (var typeIterface in type.GetInterfaces())
            {
                allInterfaces.Add(typeIterface);
                parentInterfaces.AddRange(typeIterface.GetInterfaces());
            }

            return allInterfaces.Except(parentInterfaces);
        }
    }
}
