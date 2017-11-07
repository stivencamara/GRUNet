using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GRUNet.Tests
{
    [TestClass]
    public class ValidacaoTest
    {
        [TestMethod]
        public void Valida_CPF_Valido()
        {
            var valor = "92074286520";

            var experado = Validacao.ValidaCPF(valor);

            Assert.IsTrue(experado);
        }

        [TestMethod]
        public void Valida_CPF_Invalido()
        {
            var valor = "92074286521";

            var experado = Validacao.ValidaCPF(valor);

            Assert.IsFalse(experado);
        }

        [TestMethod]
        public void Valida_CNPJ_Valido()
        {
            var valor = "65.246.402/0001-16";

            var experado = Validacao.ValidaCNPJ(valor);

            Assert.IsTrue(experado);
        }

        [TestMethod]
        public void Valida_CNPJ_Invalido()
        {
            var valor = "65.246.402/0001-11";

            var experado = Validacao.ValidaCNPJ(valor);

            Assert.IsFalse(experado);
        }
    }
    
}
