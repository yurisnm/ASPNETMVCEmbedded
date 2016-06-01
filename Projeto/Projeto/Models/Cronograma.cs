using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Projeto.Models
{
    public class Cronograma
    {

        private static List<int> horasExistentes = new List<int>() { 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18};

        public Dictionary<int, string> segunda;
        public Dictionary<int, string> terca;
        public Dictionary<int, string> quarta;
        public Dictionary<int, string> quinta;
        public Dictionary<int, string> sexta;
        public Dictionary<int, string> sabado;
        public Dictionary<int, string> domingo;

        public Cronograma()
        {
            segunda = new Dictionary<int, string>();
            terca = new Dictionary<int, string>();
            quarta = new Dictionary<int, string>();
            quinta = new Dictionary<int, string>();
            sexta = new Dictionary<int, string>();
            sabado = new Dictionary<int, string>();
            domingo = new Dictionary<int, string>();
            carrega();
        }

        /**
         * Carregar o banco de dados ou arquivo para salvar nos dicionarios.
        */
        private void carrega()
        {
            StreamReader rd = new StreamReader(@"C:\Users\Thaynan\Source\Repos\ASPNETMVCEmbedded\Projeto\Planilha.txt");
            while (!rd.EndOfStream)
            {
                string linhaAtual = rd.ReadLine();
                string[] valores = linhaAtual.Split(',');
                addNoDicionario(valores[2], valores[0], Convert.ToInt32(valores[1]));
            }
            rd.Close();
        }

        private void addNoDicionario(string pessoa, string dia, int hora)
        {
            switch (dia)
            {
                case "segunda":
                    if (horasExistentes.Contains(hora))
                    {
                        if (segunda.ContainsKey(hora))
                        {
                            string pessoasEmHorario = segunda[hora] + pessoa;
                            segunda.Add(hora, pessoasEmHorario);
                        }
                        else
                        {
                            segunda.Add(hora, pessoa);
                        }
                    }
                    break;
                case "terca":
                    if (horasExistentes.Contains(hora))
                    {
                        if (terca.ContainsKey(hora))
                        {
                            string pessoasEmHorario = terca[hora] + pessoa;
                            terca.Add(hora, pessoasEmHorario);
                        }
                        else
                        {
                            terca.Add(hora, pessoa);
                        }
                    }
                    break;
                case "quarta":
                    if (horasExistentes.Contains(hora))
                    {
                        if (quarta.ContainsKey(hora))
                        {
                            string pessoasEmHorario = quarta[hora] + pessoa;
                            quarta.Add(hora, pessoasEmHorario);
                        }
                        else
                        {
                            quarta.Add(hora, pessoa);
                        }
                    }
                    break;
                case "quinta":
                    if (horasExistentes.Contains(hora))
                    {
                        if (quinta.ContainsKey(hora))
                        {
                            string pessoasEmHorario = quinta[hora] + pessoa;
                            quinta.Add(hora, pessoasEmHorario);
                        }
                        else
                        {
                            quinta.Add(hora, pessoa);
                        }
                    }
                    break;
                case "sexta":
                    if (horasExistentes.Contains(hora))
                    {
                        if (sexta.ContainsKey(hora))
                        {
                            string pessoasEmHorario = sexta[hora] + pessoa;
                            sexta.Add(hora, pessoasEmHorario);
                        }
                        else
                        {
                            sexta.Add(hora, pessoa);
                        }
                    }
                    break;
                case "sabado":
                    if (horasExistentes.Contains(hora))
                    {
                        if (sabado.ContainsKey(hora))
                        {
                            string pessoasEmHorario = sabado[hora] + pessoa;
                            sabado.Add(hora, pessoasEmHorario);
                        }
                        else
                        {
                            sabado.Add(hora, pessoa);
                        }
                    }
                    break;
                case "domingo":
                    if (horasExistentes.Contains(hora))
                    {
                        if (domingo.ContainsKey(hora))
                        {
                            string pessoasEmHorario = domingo[hora] + pessoa;
                            domingo.Add(hora, pessoasEmHorario);
                        }
                        else
                        {
                            domingo.Add(hora, pessoa);
                        }
                    }
                    break;
            }
       }

        /**
         * Adciona pessoa no cronograma, caso possa ser realizao a operacao
        */
        public bool addPessoaNoCronograma(string dia, int hora, string nomePessoa)
        {
            

            return true;
        }

        /**
         * Metodo que tem o intuito de retornar todas as pessoas que estao neste dia e horario
        */
        public string pessoasEmHorario(string dia, int hora)
        {
            switch (dia)
            {
                case "segunda":
                    if (horasExistentes.Contains(hora) && segunda.ContainsKey(hora))
                    {
                        string pessoasEmHorario = segunda[hora];
                        return pessoasEmHorario;
                    }
                    break;
                case "terca":
                    if (horasExistentes.Contains(hora) && terca.ContainsKey(hora))
                    {
                        string pessoasEmHorario = terca[hora];
                        return pessoasEmHorario;
                    }
                    break;
                case "quarta":
                    if (horasExistentes.Contains(hora) && quarta.ContainsKey(hora))
                    {
                        string pessoasEmHorario = quarta[hora];
                        return pessoasEmHorario;
                    }
                    break;
                case "quinta":
                    if (horasExistentes.Contains(hora) && quinta.ContainsKey(hora))
                    {
                        string pessoasEmHorario = quinta[hora];
                        return pessoasEmHorario;
                    }
                    break;
                case "sexta":
                    if (horasExistentes.Contains(hora) && sexta.ContainsKey(hora))
                    {
                        string pessoasEmHorario = sexta[hora];
                        return pessoasEmHorario;
                    }
                    break;
                case "sabado":
                    if (horasExistentes.Contains(hora) && sabado.ContainsKey(hora))
                    {
                        string pessoasEmHorario = sabado[hora];
                        return pessoasEmHorario;
                    }
                    break;
                case "domingo":
                    if (horasExistentes.Contains(hora) && domingo.ContainsKey(hora))
                    {
                        string pessoasEmHorario = domingo[hora];
                        return pessoasEmHorario;
                    }
                    break;
                default:
                    return "";

            }
            return "";
        }

        private bool procuraPessoa(string listaPessoas, string pessoaDesejada)
        {
            List<string> arrayPessoas = listaPessoas.Split('\n').ToList<string>();
            foreach(string pessoaAtual in arrayPessoas)
            {
                if (pessoaAtual.ToLower().Equals(pessoaDesejada.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        /**
         *  Verifica se a pessoa se encontra neste determiando horario
        */
        public bool verificaPessoaEmHorario(string dia, int hora, string pessoa)
        {

            switch (dia)
            {
                case "segunda":
                    if (horasExistentes.Contains(hora) && segunda.ContainsKey(hora))
                    {
                        string pessoasEmHorario = segunda[hora];
                        return procuraPessoa(pessoasEmHorario, pessoa);
                    }
                    break;
                case "terca":
                    if (horasExistentes.Contains(hora) && terca.ContainsKey(hora))
                    {
                        string pessoasEmHorario = terca[hora];
                        return procuraPessoa(pessoasEmHorario, pessoa);
                    }
                    break;
                case "quarta":
                    if (horasExistentes.Contains(hora) && quarta.ContainsKey(hora))
                    {
                        string pessoasEmHorario = quarta[hora];
                        return procuraPessoa(pessoasEmHorario, pessoa);
                    }
                    break;
                case "quinta":
                    if (horasExistentes.Contains(hora) && quinta.ContainsKey(hora))
                    {
                        string pessoasEmHorario = quinta[hora];
                        return procuraPessoa(pessoasEmHorario, pessoa);
                    }
                    break;
                case "sexta":
                    if (horasExistentes.Contains(hora) && sexta.ContainsKey(hora))
                    {
                        string pessoasEmHorario = sexta[hora];
                        return procuraPessoa(pessoasEmHorario, pessoa);
                    }
                    break;
                case "sabado":
                    if (horasExistentes.Contains(hora) && sabado.ContainsKey(hora))
                    {
                        string pessoasEmHorario = sabado[hora];
                        return procuraPessoa(pessoasEmHorario, pessoa);
                    }
                    break;
                case "domingo":
                    if (horasExistentes.Contains(hora) && domingo.ContainsKey(hora))
                    {
                        string pessoasEmHorario = domingo[hora];
                        return procuraPessoa(pessoasEmHorario, pessoa);
                    }
                    break;
            }
            return false;
        }

        /**
         * Verifica se ambas as pessoas encontram-se neste determinado horario
        */
        public bool verificaVariasPessoasEmHorario(string dia, int hora, string pessoa1, string pessoa2)
        {
            
            return true;
        }
    }
}