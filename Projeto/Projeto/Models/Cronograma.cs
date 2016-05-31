using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Models
{
    public class Cronograma
    {

        public Dictionary<int, string> segunda;
        public Dictionary<int, string> terca;
        public Dictionary<int, string> quarta;
        public Dictionary<int, string> quinta;
        public Dictionary<int, string> sexta;
        public Dictionary<int, string> sabado;
        public Dictionary<int, string> domingo;
        //public List<Pessoa> pessoasCadastradas;

        public Cronograma()
        {
            segunda = new Dictionary<int, string>();
            terca = new Dictionary<int, string>();
            quarta = new Dictionary<int, string>();
            quinta = new Dictionary<int, string>();
            sexta = new Dictionary<int, string>();
            sabado = new Dictionary<int, string>();
            domingo = new Dictionary<int, string>();
            //pessoasCadastradas = new List<Pessoa>();
            carrega();
        }

        private void carrega()
        {
            //Carregar o banco de dados ou arquivo para salvar na lista de pessoas
        }

        public bool addPessoaNoCronograma(string dia, int hora, string nomePessoa)
        {
            // Adciona pessoa no cronograma, apenas um Administrador logado

            return true;
        }

        public string pessoasEmHorario(string dia, int hora)
        {
            // retornar todas as pessoas que estao neste dia e horario
            return "";
        }

        public bool verificaPessoaEmHorario(string dia, int hora, string pessoa)
        {
            // verifica se a pessoa se encontra neste determiando horario
            return true;
        }

        public bool verificaPessoasEmHorario(string dia, int hora, string pessoa1, string pessoa2)
        {
            // verifica se ambas as pessoas encontram-se neste determinado horario
            return true;
        }
    }
}