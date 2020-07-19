using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using estagio_brg.API.Data;
using estagio_brg.API.Dtos;
using estagio_brg.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace estagio_brg.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public ColaboradorController(IRepository repository, IMapper mapper){
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Colaborador
        [HttpGet]
        public IActionResult Get()
        {
            var colaboradores = _repository.GetAllColaboradores();
            return Ok(_mapper.Map<IEnumerable<ColaboradorDto>>(colaboradores));
        }

        // GET: api/Colaborador/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var colaborador = _repository.GetColaboradorById(id);
            if(colaborador == null) return BadRequest("Colaborador não foi encontrado");

            var colaboradorDto = _mapper.Map<ColaboradorDto>(colaborador);

            return Ok(colaboradorDto);
        }

         // GET: api/Colaborador/habilidade/4
        [HttpGet("habilidade/{id}", Name = "GetByHabilidadeId")]
        public IActionResult GetByHabilidadeId(int id)
        {
            var colaboradores = _repository.GetAllColaboradoresByHabilidadeId(id);
            if(colaboradores == null) return BadRequest("Colaborador não foi encontrado");
            
            return Ok(_mapper.Map<IEnumerable<ColaboradorDto>>(colaboradores));
           
        }

        // POST: api/Colaborador
        [HttpPost]
        public IActionResult Post(ColaboradorDto model)
        {
            var colaborador = _mapper.Map<Colaborador>(model);

            _repository.Add(colaborador);
            if (_repository.SaveChanges())
            {
                return Created($"/api/colaborador/{model.Id}", _mapper.Map<ColaboradorDto>(colaborador));
            }
            return BadRequest("Colaborador não cadastrado");
        }

        // PUT: api/Colaborador/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, ColaboradorDto model)
        {
            var colab = _repository.GetColaboradorById(id);
            if (colab == null) return BadRequest("Colaborador não encontrado");

            _mapper.Map(model, colab);

            _repository.Update(colab);
            if (_repository.SaveChanges()) 
            {
                return Created($"/api/colaborador/{model.Id}", _mapper.Map<ColaboradorDto>(colab));
            }
            return BadRequest("Colaborador não atualizado");
        }

        // DELETE: api/Colaborador/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var colaborador = _repository.GetColaboradorById(id);
            if (colaborador == null) return BadRequest("Colaborador não encontrado");

            _repository.Remove(colaborador);
            if (_repository.SaveChanges()) return Ok("Colaborador removido");
           
            return BadRequest("Colaborador não removido");
        }
    }
}
