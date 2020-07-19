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
    [Route("api/colaborador")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public ColaboradorController(IRepository repository, IMapper mapper){
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/colaborador
        /// <summary>
        /// Método responsável para retornar todos os Colaboradores.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var colaboradores = _repository.GetAllColaboradores();
            return Ok(_mapper.Map<IEnumerable<ColaboradorDto>>(colaboradores));
        }

        // GET: api/colaborador/5
        /// <summary>
        /// Método responsável para retornar um único Colaborador.
        /// </summary>
        /// <param name="id">Id do Coloborador.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var colaborador = _repository.GetColaboradorById(id);
            if(colaborador == null) return BadRequest("Colaborador não foi encontrado");

            var colaboradorDto = _mapper.Map<ColaboradorDto>(colaborador);

            return Ok(colaboradorDto);
        }

         // GET: api/colaborador/habilidade/4
         /// <summary>
         /// Método responsavel para retornar todos os colaboradores que possuem a Habilidade informada. 
         /// </summary>
         /// <param name="id">Id da Habilidade.</param>
         /// <returns></returns>
        [HttpGet("habilidade/{id}", Name = "GetByHabilidadeId")]
        public IActionResult GetByHabilidadeId(int id)
        {
            var colaboradores = _repository.GetAllColaboradoresByHabilidadeId(id);
            return Ok(_mapper.Map<IEnumerable<ColaboradorDto>>(colaboradores));
           
        }

        // POST: api/colaborador
        /// <summary>
        /// Método responsável por adicionar um novo Colaborador.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(ColaboradorCreateDto model)
        {
            if (!ModelState.IsValid)  return BadRequest(ModelState);

            var colaborador = _mapper.Map<Colaborador>(model);

            _repository.Add(colaborador);
            if (_repository.SaveChanges())
            {
                return Created($"/api/colaborador/{colaborador.Id}", _mapper.Map<ColaboradorDto>(colaborador));
            }
            return BadRequest("Colaborador não cadastrado");
        }

        // PUT: api/colaborador/5
        /// <summary>
        /// Método responsável por atualizar um Colaborador.
        /// </summary>
        /// <param name="id">Id do Colaborador.</param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, ColaboradorCreateDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var colaborador = _repository.GetColaboradorById(id);
            if (colaborador == null) return BadRequest("Colaborador não encontrado");

            _mapper.Map(model, colaborador);

            _repository.Update(colaborador);
            if (_repository.SaveChanges()) 
            {
                return Created($"/api/colaborador/{colaborador.Id}", _mapper.Map<ColaboradorDto>(colaborador));
            }
            return BadRequest("Colaborador não atualizado");
        }

        // DELETE: api/colaborador/5
        /// <summary>
        /// Método responsável para Remover Colaborador.
        /// </summary>
        /// <param name="id">Id do Colaborador</param>
        /// <returns></returns>
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
