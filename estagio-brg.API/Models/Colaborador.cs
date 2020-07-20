using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace estagio_brg.API.Models
{
    [Table("colaborador")]
    public class Colaborador
    {
        public Colaborador() { }

        public Colaborador(int id, string cargo, string departamento)
        {
            Id = id;
            Cargo = cargo;
            Departamento = departamento;
        }
        [Column("id")]
        public int Id { get; set; }
        [Column("cargo")]
        public string Cargo { get; set; }
        [Column("departamento")]
        public string Departamento { get; set; }

        public IEnumerable<Trilha> Trilhas { get; set; }
    }
}
