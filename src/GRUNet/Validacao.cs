﻿using System;

namespace GRUNet
{
    public static class Validacao
    {
        public static bool ValidaCNPJ(string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
                return false;

            cnpj = Utils.RemoveMascara(cnpj);

            if (cnpj.Length != 14)
                return false;

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }

        public static bool ValidaCPF(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return false;

            cpf = Utils.RemoveMascara(cpf);

            if (cpf.Length != 11)
                return false;

            int d1, d2;
            int soma = 0;
            string digitado;
            string calculado;


            // Pesos para calcular o primeiro digito
            int[] peso1 = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            // Pesos para calcular o segundo digito
            int[] peso2 = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int[] n = new int[11];

            // Caso coloque todos os numeros iguais
            switch (cpf)
            {
                case "11111111111":
                    return false;
                case "00000000000":
                    return false;
                case "2222222222":
                    return false;
                case "33333333333":
                    return false;
                case "44444444444":
                    return false;
                case "55555555555":
                    return false;
                case "66666666666":
                    return false;
                case "77777777777":
                    return false;
                case "88888888888":
                    return false;
                case "99999999999":
                    return false;
            }

            try
            {

                // Quebra cada digito do CPF
                n[0] = Convert.ToInt32(cpf.Substring(0, 1));
                n[1] = Convert.ToInt32(cpf.Substring(1, 1));
                n[2] = Convert.ToInt32(cpf.Substring(2, 1));
                n[3] = Convert.ToInt32(cpf.Substring(3, 1));
                n[4] = Convert.ToInt32(cpf.Substring(4, 1));
                n[5] = Convert.ToInt32(cpf.Substring(5, 1));
                n[6] = Convert.ToInt32(cpf.Substring(6, 1));
                n[7] = Convert.ToInt32(cpf.Substring(7, 1));
                n[8] = Convert.ToInt32(cpf.Substring(8, 1));
                n[9] = Convert.ToInt32(cpf.Substring(9, 1));
                n[10] = Convert.ToInt32(cpf.Substring(10, 1));

            }
            catch
            {

                return false;
            }


            // Calcula cada digito com seu respectivo peso
            for (int i = 0; i <= peso1.GetUpperBound(0); i++)
            {

                soma += (peso1[i] * Convert.ToInt32(n[i]));
            }

            // Pega o resto da divisao
            int resto = soma % 11;

            if (resto == 1 || resto == 0)
            {

                d1 = 0;

            }
            else
            {

                d1 = 11 - resto;
            }

            soma = 0;

            // Calcula cada digito com seu respectivo peso
            for (int i = 0; i <= peso2.GetUpperBound(0); i++)
            {

                soma += (peso2[i] * Convert.ToInt32(n[i]));
            }

            // Pega o resto da divisao
            resto = soma % 11;

            if (resto == 1 || resto == 0)
            {

                d2 = 0;

            }
            else
            {

                d2 = 11 - resto;
            }

            calculado = string.Concat(d1, d2);
            digitado = string.Concat(n[9], n[10]);

            // Se os ultimos dois digitos calculados bater com
            // os dois ultimos digitos do cpf entao é válido
            return calculado == digitado;
        }
    }
}
