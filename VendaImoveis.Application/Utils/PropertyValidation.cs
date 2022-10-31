using System.Text.RegularExpressions;

namespace VendaImoveis.Application.Utils
{
    public class PropertyValidation
    {
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

            var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var tempCpf = cpf.Substring(0, 9);
            var soma = 0;

            for (int i = 0; i < multiplicador1.Length; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            var resto = CalcularResto(soma);
            var digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < multiplicador2.Length; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

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

            var multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var tempCnpj = cnpj.Substring(0, 12);
            var soma = 0;

            for (int i = 0; i < multiplicador1.Length; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            var resto = CalcularResto(soma);
            var digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (int i = 0; i < multiplicador2.Length; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

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
