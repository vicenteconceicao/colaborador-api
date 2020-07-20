using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace estagio_brg.API.Models
{
    [Table("habilidade")]
    public class Habilidade
    {
        public Habilidade(){}

        public Habilidade(int id, string nome, int tipo)
        {
            Id = id;
            Nome = nome;
            Tipo = tipo;
        }
        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        public string Nome { get; set; }
        [Column("tipo")]
        public int Tipo { get; set; }
        public IEnumerable<Trilha> Trilhas { get; set; }
    }
}
