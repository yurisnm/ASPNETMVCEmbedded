using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Projeto.Models
{
    public class Cronograma
    {

        private static List<int> horasExistentes = new List<int>() { 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18};

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

            using (StreamReader rd = new StreamReader(@"C:\Users\Thaynan\Source\Repos\ASPNETMVCEmbedded\Projeto\Projeto\App_Data\meuArquivo.txt"))

            {
                string linhaAtual = rd.ReadLine();
                while (linhaAtual != null)
                {
                    string[] valores = linhaAtual.Split(',');
                    addNoDicionario(valores[2], valores[0], Convert.ToInt32(valores[1]));
                    linhaAtual = rd.ReadLine();
                }

           }

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
                            segunda[hora] = segunda[hora] + " " + pessoa;
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
                            terca[hora] = terca[hora] + " " + pessoa;
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
                            quarta[hora] = quarta[hora] + " " + pessoa;
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
                            quinta[hora] = quinta[hora] + " " + pessoa;
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
                            sexta[hora] = sexta[hora] + " " + pessoa;
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
                            sabado[hora] = sabado[hora] + " " + pessoa;
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
                            domingo[hora] = domingo[hora] + " " + pessoa;
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
         * Adciona pessoa no cronograma, caso possa ser realizado a operacao.
        */
        public bool addPessoaNoCronograma(string dia, int hora, string nomePessoa)
        {
            if(verificaPessoaEmHorario(dia, hora, nomePessoa) != "")
            {
               StreamWriter wr = new StreamWriter(@"C:\Users\Thaynan\Source\Repos\ASPNETMVCEmbedded\Projeto\Projeto\App_Data\meuArquivo.txt");
               wr.WriteLine(dia + " " + Convert.ToString(hora) + " " + nomePessoa);
               wr.Close();
               carrega();
               return true;
            }
            return false;
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
            List<string> arrayPessoas = listaPessoas.Split(' ').ToList<string>();
            foreach(string pessoaAtual in arrayPessoas)
            {
                if (pessoaAtual.ToLower().Equals(pessoaDesejada.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        public string getPessoaHorario()
        {
            return this.nomePessoaHorario;
        }

        /**
         *  Verifica se a pessoa se encontra neste determiando horario
        */
        public string verificaPessoaEmHorario(string dia, int hora, string pessoa)
        {
            switch (dia)
            {
                case "segunda":
                    if (horasExistentes.Contains(hora) && segunda.ContainsKey(hora))
                    {
                        string pessoasEmHorario = segunda[hora];
                        if(procuraPessoa(pessoasEmHorario, pessoa)) {
                            pessoa = char.ToUpper(pessoa[0]) + pessoa.Substring(1).ToLower();
                            return pessoa;
                        }
                    }
                    break;
                case "terca":
                    if (horasExistentes.Contains(hora) && terca.ContainsKey(hora))
                    {
                        string pessoasEmHorario = terca[hora];
                        if(procuraPessoa(pessoasEmHorario, pessoa))
                        {
                            pessoa = char.ToUpper(pessoa[0]) + pessoa.Substring(1).ToLower();
                            return pessoa;
                        }
                    }
                    break;
                case "quarta":
                    if (horasExistentes.Contains(hora) && quarta.ContainsKey(hora))
                    {
                        string pessoasEmHorario = quarta[hora];
                        if(procuraPessoa(pessoasEmHorario, pessoa))
                        {
                            pessoa = char.ToUpper(pessoa[0]) + pessoa.Substring(1).ToLower();
                            return pessoa;
                        }
                    }
                    break;
                case "quinta":
                    if (horasExistentes.Contains(hora) && quinta.ContainsKey(hora))
                    {
                        string pessoasEmHorario = quinta[hora];
                        if(procuraPessoa(pessoasEmHorario, pessoa))
                        {
                            pessoa = char.ToUpper(pessoa[0]) + pessoa.Substring(1).ToLower();
                            return pessoa;
                        }
                    }
                    break;
                case "sexta":
                    if (horasExistentes.Contains(hora) && sexta.ContainsKey(hora))
                    {
                        string pessoasEmHorario = sexta[hora];
                        if(procuraPessoa(pessoasEmHorario, pessoa))
                        {
                            pessoa = char.ToUpper(pessoa[0]) + pessoa.Substring(1).ToLower();
                            return pessoa;
                        }
                    }
                    break;
                case "sabado":
                    if (horasExistentes.Contains(hora) && sabado.ContainsKey(hora))
                    {
                        string pessoasEmHorario = sabado[hora];
                        if(procuraPessoa(pessoasEmHorario, pessoa))
                        {
                            pessoa = char.ToUpper(pessoa[0]) + pessoa.Substring(1).ToLower();
                            return pessoa;
                        }
                    }
                    break;
                case "domingo":
                    if (horasExistentes.Contains(hora) && domingo.ContainsKey(hora))
                    {
                        string pessoasEmHorario = domingo[hora];
                        if(procuraPessoa(pessoasEmHorario, pessoa))
                        {
                            pessoa = char.ToUpper(pessoa[0]) + pessoa.Substring(1).ToLower();
                            return pessoa;
                        }
                    }
                    break;
            }
            return "";
        }

        /**
         * Verifica se varias pessoas, separadas por ",", encontram-se neste determinado horario.
        */
        public string verificaVariasPessoasEmHorario(string dia, int hora, string pessoas)
        {
            string[] arrayPessoas = pessoas.Split(',');
            string nomesPessoas = "";

            for (int i=0; i < arrayPessoas.Length; i++)
            {
                string pessoaAtual = arrayPessoas[i];
                string valorPessoaNoCronograma = verificaPessoaEmHorario(dia, hora, pessoaAtual);

                if (valorPessoaNoCronograma == "") { return ""; }
                else { nomesPessoas += valorPessoaNoCronograma + " "; }
            }

            return nomesPessoas;
        }
    }
}