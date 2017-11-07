using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRUNet
{
    public sealed class Utils
    {
        public static string RemoveMascara(string valor)
        {
            return valor.Replace(".", "")
                .Replace("-", "")
                .Replace("/", "");
        }

        public static string FormataZeroEsquerda(string valor, short limite)
        {
            return valor.PadLeft(limite, '0');
        }

        /// <summary>
        /// Formata o número do CPF 92074286520 para 920.742.865-20
        /// </summary>
        /// <param name="cpf">Sequencia numérica de 11 dígitos. Exemplo: 00000000000</param>
        /// <returns>CPF formatado</returns>
        public static string FormataCPF(string cpf)
        {
            try
            {
                return string.Format("{0}.{1}.{2}-{3}", cpf.Substring(0, 3), cpf.Substring(3, 3), cpf.Substring(6, 3), cpf.Substring(9, 2));
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Formata o CNPJ. Exemplo 00.316.449/0001-63
        /// </summary>
        /// <param name="cnpj">Sequencia numérica de 14 dígitos. Exemplo: 00000000000000</param>
        /// <returns>CNPJ formatado</returns>
        public static string FormataCNPJ(string cnpj)
        {
            try
            {
                return string.Format("{0}.{1}.{2}/{3}-{4}", cnpj.Substring(0, 2), cnpj.Substring(2, 3), cnpj.Substring(5, 3), cnpj.Substring(8, 4), cnpj.Substring(12, 2));
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Formata o CPF ou CNPJ do Cedente ou do Sacado no formato: 000.000.000-00, 00.000.000/0001-00 respectivamente.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string FormataIdentificador(string cpf_cnpj)
        {
            cpf_cnpj = RemoveMascara(cpf_cnpj);

            if (cpf_cnpj.Trim().Length == 11)
                return FormataCPF(cpf_cnpj);
            else if (cpf_cnpj.Trim().Length == 14)
                return FormataCNPJ(cpf_cnpj);

            throw new Exception(string.Format("O CPF ou CNPJ: {0} é inválido.", cpf_cnpj));
        }
    }
}
