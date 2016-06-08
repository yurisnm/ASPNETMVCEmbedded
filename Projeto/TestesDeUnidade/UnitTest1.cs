using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projeto.Models;

namespace TestesDeUnidade
{
    [TestClass]
    public class TestesDoCronograma
    {
        private Cronograma cronograma;

        //Inicializando cronograma, o qual sera utilizado em todo os testes.
        [TestInitialize]
        public void IniciaTestes()
        {
            cronograma = new Cronograma();
        }

        //Testando se as pessoas carregadas no arquivo estão corretos o retorno.
        [TestMethod]
        public void TestPessoasEmHorario()
        {
            string pessoas = cronograma.pessoasEmHorario("segunda", 8);
            Assert.AreEqual("Maria / Joao / Roberta / Guilherme", pessoas);
        }
    }
}
