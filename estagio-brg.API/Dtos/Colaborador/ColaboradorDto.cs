using estagio_brg.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estagio_brg.API.Dtos
{
    public class ColaboradorDto
    {
        public int Id { get; set; }
        public string Cargo { get; set; }
        public string Departamento { get; set; }
    }
}
