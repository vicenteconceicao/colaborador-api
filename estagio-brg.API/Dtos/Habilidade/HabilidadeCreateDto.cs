using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace estagio_brg.API.Dtos
{
    public class HabilidadeCreateDto
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]
        [StringLength(50, ErrorMessage = "Nome deve ter no máximmo {1} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Tipo é obrigatório.")]
        [Range(1, 2, ErrorMessage = "Favor informar um tipo válido.")]
        public int Tipo { get; set; }
    }
}
