using System;

namespace GRUNet.Segmentos
{
    public class Segmento5 : Segmento
    {
        public Segmento5(TipoArrecadacao tipo, Unidade unidade, Contribuinte contribuinte, decimal valor):base(tipo, Leiaute.Segmento5, unidade, contribuinte, valor)
        {
        }
        public override void Valida()
        {
            if (Tipo == TipoArrecadacao.Simples)
                ValidaSimples();
            else
                ValidaJudicial();
        }

        private void ValidaSimples()
        {
            #region Leiaute do Segmento 5 (GRU Simples)
            /*             
            CAMPO POSIÇÃO (DE – ATÉ) INFORMAÇÃO DESCRIÇÃO
            --------------------------------------------------
            1   01-01   “8”     Identificação da arrecadação
            2   02-02   “5”     Segmento 5 - Órgãos Governamentais
            3   03-03   “8” ou “9”  Identificador do Valor: 8 - Reais ou 9 - Referência
            4   04-04   DV  Dígito verificador geral – módulo 11
            5   05-15   Valor   Valor do Documento GRU Simples
            6   16-19   “0254”  Código STN junto à FEBRABAN
            7   20-24   Código de recolhimento sem o dígito verificador     Código de recolhimento
            8   25-29   “Apelido” da UG/Gestão  Código identificador da UG/Gestão responsável pela arrecadação, obtido por meio da transação >CONCODBBGR do SIAFI Operacional
            9   30-30   “1” ou “2”  Tipo de contribuinte: 1 - CPF ou 2 - CNPJ
            10  31-44   CNPJ ou CPF     Identificação do contribuinte 
            */
            #endregion Leiaute do Segmento 5 (GRU Simples)

            var campo1 = "8";
            var campo2 = "5";
            var campo3 = "8";
            var campo4 = "";
            var campo5 = "";
            var campo6 = "0254";
            var campo7 = "";
            var campo8 = "";
            var campo9 = (int)Contribuinte.Tipo;
            var campo10 = "";

            #region Campo 5

            if (Valor == 0)
                throw new GRUException("O valor do documento não pode ser zero");

            string valor = Valor.ToString("f").Replace(",", "").Replace(".", "");
            campo5 = Utils.FormataZeroEsquerda(valor, 11);

            #endregion Campo 5

            #region Campo 7

            if (string.IsNullOrEmpty(Unidade.CodigoRecolhimento))
                throw new GRUException("O código do recolhimento não pode ser vazio ou nulo");

            var partes = Unidade.CodigoRecolhimento.Split('-');

            if (partes.Length != 2)
                throw new GRUException("O código do recolhimento não apresenta o dígito verificador");

            var codigoRecolhimento = partes[0];

            if (codigoRecolhimento.Length != 5)
                throw new GRUException("Código de recolhimento inválido");

            campo7 = codigoRecolhimento;

            #endregion

            #region Campo 8

            var codigoSIAFI = Unidade.CodigoSIAFI;

            if (string.IsNullOrEmpty(codigoSIAFI) || codigoSIAFI == "00000")
                throw new GRUException("Código de arrecadação da Unidade Gestora do SIAFI inválido");

            campo8 = Utils.FormataZeroEsquerda(codigoSIAFI, 5);

            #endregion Campo 8

            #region Campo 10

            var identificador = Utils.RemoveMascara(Contribuinte.Identificacao);

            campo10 = Utils.FormataZeroEsquerda(identificador, 14);

            if (string.IsNullOrEmpty(campo10) || campo10.Length != 14)
                throw new GRUException("Campo 10 inválido");

            #endregion 

            var modulo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}",
                campo1, campo2, campo3, campo5, campo6, campo7, campo8, campo9, campo10);

            if (modulo.Length != 43)
                throw new GRUException("Módulo inválido");

            campo4 = Modulo11.Calcula(modulo).ToString();

            CodigoBarras = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}",
                campo1, campo2, campo3, campo4, campo5, campo6, campo7, campo8, campo9, campo10);
        }

        private void ValidaJudicial()
        {
            throw new NotImplementedException();
        }
    }
}
