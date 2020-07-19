using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace estagio_brg.API.Dtos.Trilha
{
    public class TrilhaCreateDto
    {
        [Required(ErrorMessage = "Colaborador é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "Colaborador é obrigatório.")]
        public int ColaboradorId { get; set; }

        [Required(ErrorMessage = "Habilidade é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "Habilidade é obrigatória.")]
        public int HabilidadeId { get; set; }

        [Required(ErrorMessage = "Prazo é obrigatório.")]
        public DateTime Prazo { get; set; }
    }
}
