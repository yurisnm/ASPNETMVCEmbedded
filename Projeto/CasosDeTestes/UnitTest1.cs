using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projeto.Models;

namespace CasosDeTestes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Cronograma c = new Cronograma();
            string pessoas = c.pessoasEmHorario("segunda", 8);
            Assert.AreEqual("Maria / Joao / Roberta / Guilherme", pessoas);
        }
    }
}
