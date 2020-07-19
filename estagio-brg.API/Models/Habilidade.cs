using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estagio_brg.API.Models
{
    public class Habilidade
    {
        public Habilidade(){}

        public Habilidade(int id, string nome, int tipo)
        {
            Id = id;
            Nome = nome;
            Tipo = tipo;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Tipo { get; set; }
        public IEnumerable<Trilha> Trilhas { get; set; }
    }
}
