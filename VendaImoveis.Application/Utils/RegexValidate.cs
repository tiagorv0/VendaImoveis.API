using System.Text.RegularExpressions;

namespace VendaImoveis.Application.Utils
{
    public class RegexValidate
    {
        public static bool TelefoneEhValido(string telefone)
        {
            return new Regex(@"^\(?[1-9]{2}\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$").IsMatch(telefone);
        }

        public static bool CPFEhValido(string cpf)
        {
            return new Regex(@"/^\d{3}\.\d{3}\.\d{3}\-\d{2}$/").IsMatch(cpf);
        }

        public static bool CNPJEhValido(string cnpj)
        {
            return new Regex(@"\d{2}.?\d{3}.?\d{3}/?\d{4}-?\d{2}").IsMatch(cnpj);
        }

        public static bool SenhaEhValido(string senha)
        {
            return new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$_!%*?&-])[A-Za-z\d@$!_%*?&-]{8,}$").IsMatch(@senha);
        }
    }
}
