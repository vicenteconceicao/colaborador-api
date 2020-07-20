using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace estagio_brg.API.Models
{
    [Table("trilha")]
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
        [Column("id")]
        public int Id { get; set; }
        [Column("colaborador_id")]
        public int ColaboradorId { get; set; }
        public Colaborador Colaborador { get; set; }
        [Column("habilidade_id")]
        public int HabilidadeId { get; set; }
        public Habilidade Habilidade { get; set; }
        [Column("prazo")]
        public DateTime Prazo { get; set; }
    }
}
