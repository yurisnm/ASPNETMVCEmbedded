using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace Projeto.Models
{
    public class Cronograma
    {
        [Required(ErrorMessage = "Nome não pode ser vazio.")]
        public string nomePessoaHorario { get; set; } = "nome1,nome2,nome3";

        [Required(ErrorMessage = "Horário não pode ser vazio.")]
        public int horarioRequest { get; set; } = 0;

        [Required(ErrorMessage = "Dia da semana não pode ser vazio.")]
        public string diaRequest { get; set; } = "Segunda";

        [Required(ErrorMessage ="Nome não pode ser vazio.")]
        public string alunoNovo { get; set; } = "Nome Sobrenome";

        [Required(ErrorMessage = "Dia da semana não pode ser vazio.")]
        public string diaNovo { get; set; } = "Segunda";
        
        [Required(ErrorMessage = "Horário não pode ser vazio.")]
        public int horaNovo { get; set; } = 8;

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

        public string getPessoaHorario()
        {
            return this.nomePessoaHorario;
        }

        public int getHorarioRequest()
        {
            return this.horarioRequest;
        }

        public string getDiaRequest()
        {
            string retorno = this.diaRequest;
            if (!string.IsNullOrEmpty(retorno))
            {
                retorno = char.ToUpper(retorno[0]) + retorno.Substring(1).ToLower();
            }
            return retorno;
        }

        public string getAlunoNovo()
        {
            return this.alunoNovo;
        }

        public string getDiaNovo()
        {
            return this.diaNovo;
        }

        public int getHoraNovo()
        {
            return this.horaNovo;
        }

        /**
         * Carregar o banco de dados ou arquivo para salvar nos dicionarios.
        */
        private void carrega()
        {
            //using (StreamReader rd = new StreamReader(@"C:\Users\Thaynan\Source\Repos\ASPNETMVCEmbedded\Projeto\Projeto\meuArquivo.txt"))
            using (StreamReader rd = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\meuArquivo.txt"))
            {
                string linhaAtual = rd.ReadLine();
                while (linhaAtual != null)
                {
                    string[] valores = linhaAtual.Split(',');
                    string pessoas = valores[2];
                    int hora = Convert.ToInt32(valores[1]);
                    string dia = valores[0];
                    addNoDicionario(pessoas, dia, hora);
                    linhaAtual = rd.ReadLine();
                }

           }
        }

        /**
         * Metodo responsavel por adcionar uma ou varias pessoas em determinado dicionario, dirigido por dia e hora.
        */
        private void addNoDicionario(string pessoas, string dia, int hora)
        {
            switch (dia.ToLower())
            {
                case "segunda":
                    if (horasExistentes.Contains(hora))
                    {
                        if (segunda.ContainsKey(hora))
                            segunda[hora] = segunda[hora] + " / " + pessoas;

                        else
                            segunda.Add(hora, pessoas);
                    }   
                    break;
                case "terca":
                    if (horasExistentes.Contains(hora))
                    {
                        if (terca.ContainsKey(hora))
                            terca[hora] = terca[hora] + " / " + pessoas;

                        else
                            terca.Add(hora, pessoas);
                    }
                    break;
                case "quarta":
                    if (horasExistentes.Contains(hora))
                    {
                        if (quarta.ContainsKey(hora))
                            quarta[hora] = quarta[hora] + " / " + pessoas;

                        else
                            quarta.Add(hora, pessoas);
                    }
                    break;
                case "quinta":
                    if (horasExistentes.Contains(hora))
                    {
                        if (quinta.ContainsKey(hora))
                            quinta[hora] = quinta[hora] + " / " + pessoas;

                        else
                            quinta.Add(hora, pessoas);
                    }
                    break;
                case "sexta":
                    if (horasExistentes.Contains(hora))
                    {
                        if (sexta.ContainsKey(hora))
                            sexta[hora] = sexta[hora] + " / " + pessoas;

                        else
                            sexta.Add(hora, pessoas);
                    }
                    break;
                case "sabado":
                    if (horasExistentes.Contains(hora))
                    {
                        if (sabado.ContainsKey(hora))
                            sabado[hora] = sabado[hora] + " / " + pessoas;

                        else
                            sabado.Add(hora, pessoas);
                    }
                    break;
                case "domingo":
                    if (horasExistentes.Contains(hora))
                    {
                        if (domingo.ContainsKey(hora))
                            domingo[hora] = domingo[hora] + " / " + pessoas;

                        else
                            domingo.Add(hora, pessoas);
                    }
                    break;
            }
       }

        /**
         * Adciona pessoa no cronograma, caso possa ser realizado a operacao.
        */
        public bool addPessoaNoCronograma(string dia, int hora, string nomePessoa)
        {
            if (!string.IsNullOrEmpty(dia) && !string.IsNullOrEmpty(nomePessoa) && horasExistentes.Contains(hora))
            {
                if (pessoasEmHorario(dia, hora, nomePessoa) == "")
                {
                    //StreamWriter wr = new StreamWriter(@"C:\Users\Thaynan\Source\Repos\ASPNETMVCEmbedded\Projeto\Projeto\meuArquivo.txt", true);
                    StreamWriter wr = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\meuArquivo.txt", true);

                    wr.WriteLine(dia + "," + Convert.ToString(hora) + "," + nomePessoa);
                    wr.Close();
                    carrega();
                    return true;
                }
            }
            return false;
        }

        private bool procuraPessoa(string listaPessoas, string pessoaDesejada)
        {
            List<string> arrayPessoas = listaPessoas.Split(new string[] { " / " }, StringSplitOptions.None).ToList<string>();
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
        * Metodo que tem o intuito de retornar todas as pessoas que estao neste dia e horario
       */
        public string pessoasEmHorario(string dia, int hora, string pessoas)
        {
            if (!string.IsNullOrEmpty(dia) && horasExistentes.Contains(hora))
            {
                switch (dia.ToLower())
                {
                    case "segunda":
                        if (segunda.ContainsKey(hora))
                        {
                            string pessoasNoHorario = segunda[hora];
                            if (!string.IsNullOrEmpty(pessoas)){
                                if (procuraPessoa(pessoasNoHorario, pessoas))
                                {
                                    pessoas = char.ToUpper(pessoas[0]) + pessoas.Substring(1).ToLower();
                                    return pessoas;
                                }
                            }
                            else
                                return pessoasNoHorario;
                        }
                        break;
                    case "terca":
                        if (terca.ContainsKey(hora))
                        {
                            string pessoasNoHorario = terca[hora];
                            if (!string.IsNullOrEmpty(pessoas))
                            {
                                if (procuraPessoa(pessoasNoHorario, pessoas))
                                {
                                    pessoas = char.ToUpper(pessoas[0]) + pessoas.Substring(1).ToLower();
                                    return pessoas;
                                }
                            }
                            else
                                return pessoasNoHorario;
                        }
                        break;
                    case "quarta":
                        if (quarta.ContainsKey(hora))
                        {
                            string pessoasNoHorario = quarta[hora];
                            if (!string.IsNullOrEmpty(pessoas))
                            {
                                if (procuraPessoa(pessoasNoHorario, pessoas))
                                {
                                    pessoas = char.ToUpper(pessoas[0]) + pessoas.Substring(1).ToLower();
                                    return pessoas;
                                }
                            }
                            else
                                return pessoasNoHorario;
                        }
                        break;
                    case "quinta":
                        if (quinta.ContainsKey(hora))
                        {
                            string pessoasNoHorario = quinta[hora];
                            if (!string.IsNullOrEmpty(pessoas))
                            {
                                if (procuraPessoa(pessoasNoHorario, pessoas))
                                {
                                    pessoas = char.ToUpper(pessoas[0]) + pessoas.Substring(1).ToLower();
                                    return pessoas;
                                }
                            }
                            else
                                return pessoasNoHorario;
                        }
                        break;
                    case "sexta":
                        if (sexta.ContainsKey(hora))
                        {
                            string pessoasNoHorario = sexta[hora];
                            if (!string.IsNullOrEmpty(pessoas))
                            {
                                if (procuraPessoa(pessoasNoHorario, pessoas))
                                {
                                    pessoas = char.ToUpper(pessoas[0]) + pessoas.Substring(1).ToLower();
                                    return pessoas;
                                }
                            }
                            else
                                return pessoasNoHorario;
                        }
                        break;
                    case "sabado":
                        if (sabado.ContainsKey(hora))
                        {
                            string pessoasNoHorario = sabado[hora];
                            if (!string.IsNullOrEmpty(pessoas))
                            {
                                if (procuraPessoa(pessoasNoHorario, pessoas))
                                {
                                    pessoas = char.ToUpper(pessoas[0]) + pessoas.Substring(1).ToLower();
                                    return pessoas;
                                }
                            }
                            else
                                return pessoasNoHorario;
                        }
                        break;
                    case "domingo":
                        if (domingo.ContainsKey(hora))
                        {
                            string pessoasNoHorario = domingo[hora];
                            if (!string.IsNullOrEmpty(pessoas))
                            {
                                if (procuraPessoa(pessoasNoHorario, pessoas))
                                {
                                    pessoas = char.ToUpper(pessoas[0]) + pessoas.Substring(1).ToLower();
                                    return pessoas;
                                }
                            }
                            else
                                return pessoasNoHorario;
                        }
                        break;
                    default:
                        return "";
                }
            }
            return "";
        }

        /**
         * Verifica se varias pessoas, separadas por ",", encontram-se neste determinado horario.
        */
        public string verificaVariasPessoasEmHorario(string dia, int hora, string pessoas){

            string nomesPessoas = "";
            if (!string.IsNullOrEmpty(dia) && !string.IsNullOrEmpty(pessoas) && horasExistentes.Contains(hora))
            {
                string[] arrayPessoas = pessoas.Split(',');
                for (int i = 0; i < arrayPessoas.Length; i++)
                {
                    string pessoaAtual = arrayPessoas[i];
                    string valorPessoaNoCronograma = pessoasEmHorario(dia, hora, pessoaAtual);

                    if (valorPessoaNoCronograma == "") { return ""; }
                    else if (i < (arrayPessoas.Length - 1)) { nomesPessoas += valorPessoaNoCronograma + " / "; }
                    else { nomesPessoas += valorPessoaNoCronograma; }
                }
            }
            return nomesPessoas;
        }
    }
}