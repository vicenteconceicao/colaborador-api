using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estagio_brg.API.Models
{
    public class Colaborador
    {
        public Colaborador(){}

        public Colaborador(int id, string cargo, string departamento)
        {
            Id = id;
            Cargo = cargo;
            Departamento = departamento;
        }
        public int Id { get; set; }
        public string Cargo { get; set; }
        public string Departamento { get; set; }

        public IEnumerable<Trilha> Trilhas { get; set; }
    }
}
