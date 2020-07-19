using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estagio_brg.API.Models
{
    public class Trilha
    {
        public Trilha(){}

        public Trilha(int id, int colaboradorId, int habilidadeId, DateTime prazo)
        {
            Id = id;
            ColaboradorId = colaboradorId;
            HabilidadeId = habilidadeId;
            Prazo = prazo;
        }

        public int Id { get; set; }
        public int ColaboradorId { get; set; }
        public Colaborador Colaborador { get; set; }
        public int HabilidadeId { get; set; }
        public Habilidade Habilidade { get; set; }
        public DateTime Prazo { get; set; }
    }
}
