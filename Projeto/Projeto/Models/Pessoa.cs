using System.Collections.Generic;

namespace Projeto.Models
{
    public class Pessoa
    {
        private string Nome { get; set; }
        private Dictionary<string, List<int>> horarios;

        public Pessoa(string nomePessoa)
        {
            Nome = nomePessoa;
            horarios = new Dictionary<string, List<int>>()
            {
                {"segunda", new List<int>()},
                {"terca", new List<int>()},
                {"quarta", new List<int>()},
                {"quinta", new List<int>()},
                {"sexta", new List<int>()},
                {"sabado", new List<int>()},
                {"domingo", new List<int>()}
            };
        }

        public string getNome()
        {
            return Nome;
        }

        public void addHorario(string dia, int hora)
        {
            if (horarios.ContainsKey(dia))
            {
                List<int> lista = horarios[dia];
                lista.Add(hora);
                horarios.Add(dia, lista);
            }
            
            /*foreach(var item in horarios)
            {
                if (item.Key.Equals(dia))
                    {
                        List<int> lista = item.Value;
                        if(lista == null)
                        {
                            lista = new List<int>;
                        }
                        lista.Add(hora);
                        horarios.Add(dia, lista);
                    }
            }*/
                
       }
    }
}