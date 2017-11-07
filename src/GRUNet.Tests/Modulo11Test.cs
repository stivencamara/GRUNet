using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://cmsportal.febraban.org.br/Arquivos/documentos/PDF/Layout%20-%20C%C3%B3digo%20de%20Barras%20-%20Vers%C3%A3o%205%20-%2001_08_2016.pdf

namespace GRUNet.Tests
{
    [TestClass]
    public class Modulo11Test
    {
        [TestMethod]
        public void Calcular()
        {
            //
            var experado = Modulo11.Calcula("01230067896");

            Assert.IsTrue(experado == 0);
        }

        [TestMethod]
        public void Calcular_1()
        {
            var experado = Modulo11.Calcula("8220000215048200974123220154098290108605940");

            Assert.IsTrue(experado == 0);
        } 
    }
}
