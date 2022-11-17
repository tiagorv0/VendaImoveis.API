using System.Text.RegularExpressions;

namespace VendaImoveis.Application.Utils
{
    public class PropertyValidation
    {
        static int[] MULTIPLICADORCPF1 = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        static int[] MULTIPLICADORCPF2 = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        static int[] MULTIPLICADORCNPJ1 = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        static int[] MULTIPLICADORCNPJ2 = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        public static bool TelefoneEhValido(string telefone)
        {
            return new Regex(@"^\(?[1-9]{2}\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$").IsMatch(telefone);
        }

        public static bool SenhaEhValido(string senha)
        {
            return new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$_!%*?&-])[A-Za-z\d@$!_%*?&-]{8,}$").IsMatch(@senha);
        }

        public static bool CPFEhValido(string cpf)
        {
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;

            var tempCpf = cpf.Substring(0, 9);
            var soma = 0;

            for (int i = 0; i < MULTIPLICADORCPF1.Length; i++)
                soma += (tempCpf[i] - '0') * MULTIPLICADORCPF1[i];

            var resto = CalcularResto(soma);
            var digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < MULTIPLICADORCPF2.Length; i++)
                soma += (tempCpf[i] - '0') * MULTIPLICADORCPF2[i];

            resto = CalcularResto(soma);
            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        public static bool CNPJEhValido(string cnpj)
        {
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            
            var tempCnpj = cnpj.Substring(0, 12);
            var soma = 0;

            for (int i = 0; i < MULTIPLICADORCNPJ1.Length; i++)
                soma += (tempCnpj[i] - '0') * MULTIPLICADORCNPJ1[i];

            var resto = CalcularResto(soma);
            var digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (int i = 0; i < MULTIPLICADORCNPJ2.Length; i++)
                soma += (tempCnpj[i] - '0') * MULTIPLICADORCNPJ2[i];

            resto = CalcularResto(soma);
            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }

        private static int CalcularResto(int soma)
        {
            int resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            return resto;
        }
    }
}
