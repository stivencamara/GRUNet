using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GRUNet.Tests
{
    [TestClass]
    public class BoletoTest
    {
        /// <summary>
        /// Teste utilizado como base o site http://consulta.tesouro.fazenda.gov.br/gru_novosite/gru_simples.asp
        /// e com os mesmo parâmetros
        /// </summary>
        [TestMethod]
        public void GRU_Simples_Valida_CodigoBarras_CPF()
        {
            var cliente = new Unidade("FUNDO DE ADMINISTRAÇÃO DO HOSPITAL DAS FORÇAS ARMADAS", "03.568.867/0001-36", "204", "112408", "00001", "28883-7", "0150114062");

            var enderecoContribuinte = new Endereco("SQN 416 K 106", "Asa Norte", "Brasília", "DF", "70879-110");

            var contribuinte = new Contribuinte(TipoContribuinte.CPF, "920.742.865-20", "Stiven Fabiano da Câmara", enderecoContribuinte);

            var boleto = new Guia(TipoArrecadacao.Simples, Leiaute.Segmento5, cliente, contribuinte, 120);

            boleto.Processa();

            var codigoBarras = boleto.LinhaDigitavel;

            Assert.IsTrue(codigoBarras == "85870000001-4 20000254288-1 83002041000-2 92074286520-9");
        }

        /// <summary>
        /// Teste utilizado como base o site http://consulta.tesouro.fazenda.gov.br/gru_novosite/gru_simples.asp
        /// e com os mesmo parâmetros
        /// </summary>
        [TestMethod]        
        public void GRU_Simples_Valida_CodigoBarras_CNPJ()
        {
            var cliente = new Unidade("FUNDO DE ADMINISTRAÇÃO DO HOSPITAL DAS FORÇAS ARMADAS", "03.568.867/0001-36", "204", "112408", "00001", "28883-7", "0150114062");

            var enderecoContribuinte = new Endereco("SQN 416 K 106", "Asa Norte", "Brasília", "DF", "70879-110");

            var contribuinte = new Contribuinte(TipoContribuinte.CNPJ, "70.853.056/0001-74", "Stiven Fabiano da Câmara ME", enderecoContribuinte);

            var boleto = new Guia(TipoArrecadacao.Simples, Leiaute.Segmento5, cliente, contribuinte, 120);

            boleto.Processa();

            var codigoBarras = boleto.LinhaDigitavel;

            Assert.IsTrue(codigoBarras == "85800000001-1 20000254288-1 83002042708-8 53056000174-0");
        }
    }
}
