using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace estagio_brg.API.Dtos
{
    public class ColaboradorCreateDto
    {
        [Required(ErrorMessage = "Cargo é obrigatório.")]
        [StringLength(50, ErrorMessage = "Cargo deve ter no máximmo {1} caracteres.")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "Departamento é obrigatório.")]
        [StringLength(50, ErrorMessage = "Departamento deve ter no máximmo {1} caracteres.")]
        public string Departamento { get; set; }
    }
}
