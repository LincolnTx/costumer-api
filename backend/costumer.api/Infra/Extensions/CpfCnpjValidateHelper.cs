using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace costumer.api.Infra.Extensions
{
    public static class CpfCnpjValidateHelper
    {
        public static bool ValidateCnpj(string cnpj)
        {
            if (!(cnpj is string))
            {
                return false;
            }

            var knownInvalidCnpjs = new List<string>() {
                "00000000000000",
                "11111111111111",
                "22222222222222",
                "33333333333333",
                "44444444444444",
                "55555555555555",
                "66666666666666",
                "77777777777777",
                "88888888888888",
                "99999999999999" };

            cnpj = Regex.Replace(cnpj, @"\D", "");

            if (cnpj.Length != 14)
            {
                return false;
            }

            if (knownInvalidCnpjs.Contains(cnpj))
            {
                return false;
            }

            return ValidateDigitCnpj(cnpj);
        }

        private static bool ValidateDigitCnpj(string cnpj)
        {
            int resto;
            string digitoVerificador;
            string cnpjSemDigitoVerificador;
            string cnpjComDigitoVerificador;

            int somaMultiplicador1;
            int somaMultiplicador2;
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            cnpjSemDigitoVerificador = cnpj.Substring(0, 12);
            somaMultiplicador1 = 0;

            for (int i = 0; i < 12; i++)
            {
                somaMultiplicador1 += int.Parse(cnpjSemDigitoVerificador[i].ToString()) * multiplicador1[i];
            }

            resto = (somaMultiplicador1 % 11);

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digitoVerificador = resto.ToString();
            cnpjComDigitoVerificador = cnpjSemDigitoVerificador + digitoVerificador;
            somaMultiplicador2 = 0;

            for (int i = 0; i < 13; i++)
            {
                somaMultiplicador2 += int.Parse(cnpjComDigitoVerificador[i].ToString()) * multiplicador2[i];
            }

            resto = (somaMultiplicador2 % 11);

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digitoVerificador = digitoVerificador + resto.ToString();

            return cnpj.EndsWith(digitoVerificador);
        }

        public static bool ValidateCpf(string cpf)
        {
            if (!(cpf is string))
            {
                return false;
            }

            var knownInvalidCpfs = new List<string>() {
                "00000000000",
                "11111111111",
                "22222222222",
                "33333333333",
                "44444444444",
                "55555555555",
                "66666666666",
                "77777777777",
                "88888888888",
                "99999999999" };

            cpf = Regex.Replace(cpf, @"\D", "");

            if (cpf.Length != 11)
            {
                return false;
            }

            if (knownInvalidCpfs.Contains(cpf))
            {
                return false;
            }

            return ValidateDigitCpf(cpf);
        }

        private static bool ValidateDigitCpf(string cpf)
        {
            int resto;
            string digitoVerificador;
            string cpfSemDigitoVerificador;
            string cpfComDigitoVerificador;

            int somaMultiplicador1;
            int somaMultiplicador2;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
            {
                return false;
            }

            cpfSemDigitoVerificador = cpf.Substring(0, 9);
            somaMultiplicador1 = 0;

            for (int i = 0; i < 9; i++)
            {
                somaMultiplicador1 += int.Parse(cpfSemDigitoVerificador[i].ToString()) * multiplicador1[i];
            }

            resto = somaMultiplicador1 % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digitoVerificador = resto.ToString();
            cpfComDigitoVerificador = cpfSemDigitoVerificador + digitoVerificador;
            somaMultiplicador2 = 0;

            for (int i = 0; i < 10; i++)
            {
                somaMultiplicador2 += int.Parse(cpfComDigitoVerificador[i].ToString()) * multiplicador2[i];
            }

            resto = somaMultiplicador2 % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digitoVerificador = digitoVerificador + resto.ToString();

            return cpf.EndsWith(digitoVerificador);
        }
    }
}
