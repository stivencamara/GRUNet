using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRUNet.Tests
{ 
    [TestClass]
    public class UtilsTest
    {
        [TestClass]
        public class BoletoTest
        {
            [TestMethod]
            public void FormatZeroEsquerda()
            {
                var valor = "92074286520";

                var experado = Utils.FormataZeroEsquerda(valor, 14);

                Assert.IsTrue(experado == "00092074286520");
            }
        }
    }
}
