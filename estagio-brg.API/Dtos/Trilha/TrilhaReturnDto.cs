using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estagio_brg.API.Dtos.Trilha
{
    public class TrilhaReturnDto
    {
        public int Id { get; set; }
        public int ColaboradorId { get; set; }
        public int HabilidadeId { get; set; }
        public DateTime Prazo { get; set; }
    }
}
