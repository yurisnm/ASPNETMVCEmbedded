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
            string pessoasSegunda8Horas = cronograma.pessoasEmHorario("segunda", 8);
            Assert.AreEqual("Maria / Joao / Roberta / Guilherme", pessoasSegunda8Horas);

            string pessoasTerca12Horas = cronograma.pessoasEmHorario("terca", 12);
            Assert.AreEqual("Luciana / Luciano / Carlos / Yuri", pessoasTerca12Horas);

            string pessoasSexta9Horas = cronograma.pessoasEmHorario("sexta", 9);
            Assert.AreEqual("Luana / Marcela / Claudia", pessoasSexta9Horas);

            string pessoasDomingo13Horas = cronograma.pessoasEmHorario("domingo", 13);
            Assert.AreEqual("", pessoasDomingo13Horas);

            string pessoasSabado15Horas = cronograma.pessoasEmHorario("sabado", 15);
            Assert.AreEqual("Luciana / Beatriz / Luiz", pessoasSabado15Horas);

            string pessoasQuarta11Horas = cronograma.pessoasEmHorario("quarta", 11);
            Assert.AreEqual("", pessoasQuarta11Horas);

            string pessoasQuinta18Horas = cronograma.pessoasEmHorario("quinta", 18);
            Assert.AreEqual("Roberto", pessoasQuinta18Horas);

            string pessoasTerca10Horas = cronograma.pessoasEmHorario("terca", 10);
            Assert.AreEqual("Joao Claudio / Beatriz / Thaynan", pessoasTerca10Horas);
        }

        //Testando se o retorno da busca por pessoas em determinados horarios esta correta
        [TestMethod]
        public void TestVerificaVariasPessoasEmHorario()
        {
            string joaoSegunda8Horas = cronograma.verificaVariasPessoasEmHorario("segunda", 8, "joao");
            Assert.AreEqual("Joao", joaoSegunda8Horas);

            string mariaTerca10Horas = cronograma.verificaVariasPessoasEmHorario("terca", 10, "maria");
            Assert.AreEqual("", mariaTerca10Horas);

            string LucasPedroQuarta10Horas = cronograma.verificaVariasPessoasEmHorario("quarta", 10, "lucas,pedro");
            Assert.AreEqual("", LucasPedroQuarta10Horas);

            string robertoQuinta18Horas = cronograma.verificaVariasPessoasEmHorario("quinta", 18, "roberto");
            Assert.AreEqual("Roberto", robertoQuinta18Horas);

            string cesarPedroGabrielQuinta10Horas = cronograma.verificaVariasPessoasEmHorario("quinta", 10, "cesar,pedro,gabriel");
            Assert.AreEqual("Cesar / Pedro / Gabriel", cesarPedroGabrielQuinta10Horas);

            string pedroRobertaSexta13Horas = cronograma.verificaVariasPessoasEmHorario("sexta", 13, "pedro,roberta");
            Assert.AreEqual("Pedro / Roberta", pedroRobertaSexta13Horas);

            string AndreyYuriSabado10Horas = cronograma.verificaVariasPessoasEmHorario("sabado", 10, "andrey,yuri");
            Assert.AreEqual("Andrey / Yuri", AndreyYuriSabado10Horas);

            string BeatrizLucianaAlineSexta16Horas = cronograma.verificaVariasPessoasEmHorario("sexta", 16, "beatriz,luciana,aline");
            Assert.AreEqual("Beatriz / Luciana / Aline", BeatrizLucianaAlineSexta16Horas);

            string MarceloAnaLuciaThaynanSegunda14Horas = cronograma.verificaVariasPessoasEmHorario("segunda", 14, "marcelo,ana lucia,thaynan");
            Assert.AreEqual("Marcelo / Ana lucia / Thaynan", MarceloAnaLuciaThaynanSegunda14Horas);
        }

        //Teste que verifica se um pessoa foi adcionado no cronograma.
        [TestMethod]
        public void TestAddPessoaNoCronograma()
        {
            Assert.IsTrue(cronograma.addPessoaNoCronograma("segunda", 8, "lucas"));
            string lucasSegunda8Horas = cronograma.verificaVariasPessoasEmHorario("segunda", 8, "lucas");
            Assert.AreEqual("Lucas", lucasSegunda8Horas);

            
            Assert.IsTrue(cronograma.addPessoaNoCronograma("quinta", 18, "maria"));
            string mariaQuinta18Horas = cronograma.verificaVariasPessoasEmHorario("quinta", 18, "maria");
            Assert.AreEqual("Maria", mariaQuinta18Horas);

            
            Assert.IsTrue(cronograma.addPessoaNoCronograma("quinta", 11, "Valdo"));
            string valdoQuinta10Horas = cronograma.verificaVariasPessoasEmHorario("quinta", 11, "Valdo");
            Assert.AreEqual("Valdo", valdoQuinta10Horas);


            Assert.IsFalse(cronograma.addPessoaNoCronograma("segunda", 8, "Lucas"));
            
            Assert.IsTrue(cronograma.addPessoaNoCronograma("sabado", 17, "Ribeirinho"));
            string ribeirinhoSabado17Horas = cronograma.verificaVariasPessoasEmHorario("sabado", 17, "Ribeirinho");
            Assert.AreEqual("Ribeirinho", ribeirinhoSabado17Horas);


            Assert.IsTrue(cronograma.addPessoaNoCronograma("quarta", 10, "Joao"));
            string joaoQuarta10Horas = cronograma.verificaVariasPessoasEmHorario("quarta", 10, "Joao");
            Assert.AreEqual("Joao", joaoQuarta10Horas);


            Assert.IsTrue(cronograma.addPessoaNoCronograma("domingo", 8, "Marcela"));
            string MarcelaDomingo8Horas = cronograma.verificaVariasPessoasEmHorario("domingo", 8, "Marcela");
            Assert.AreEqual("Marcela", MarcelaDomingo8Horas);


            Assert.IsFalse(cronograma.addPessoaNoCronograma("segunda", 8, "Lucas"));

            Assert.IsFalse(cronograma.addPessoaNoCronograma("terca", 12, "Luciana"));

            Assert.IsFalse(cronograma.addPessoaNoCronograma("quinta", 10, "Cesar"));
        }
    }
}
