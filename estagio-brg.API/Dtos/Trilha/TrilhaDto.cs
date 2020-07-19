using estagio_brg.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estagio_brg.API.Dtos
{
    public class TrilhaDto
    {
        public int Id { get; set; }
        public ColaboradorDto Colaborador { get; set; }
        public HabilidadeDto Habilidade { get; set; }
        public DateTime Prazo { get; set; }
    }
}
