using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using estagio_brg.API.Data;
using estagio_brg.API.Dtos;
using estagio_brg.API.Dtos.Trilha;
using estagio_brg.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace estagio_brg.API.Controllers
{
    [Route("api/trilha")]
    [ApiController]
    public class TrilhaController : ControllerBase
    {
        private IRepository _repository;
        private IMapper _mapper;

        public TrilhaController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/trilha
        /// <summary>
        /// Método responsável para retornar todas as Trilhas.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var trilhas = _repository.GetAllTrilhas();
            return Ok(_mapper.Map<IEnumerable<TrilhaDto>>(trilhas));
        }

        // GET: api/trilha/5
        /// <summary>
        ///  Método responsável para retornar uma única Trilha.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var trilha = _repository.GetTrilhaById(id);
            if (trilha == null) return BadRequest("Trilha não foi encontrada");

            var trilhaDto = _mapper.Map<TrilhaDto>(trilha);
            return Ok(trilhaDto);
        }

        // GET: api/trilha/colaborador/4
        /// <summary>
        /// Método responsavel para retornar todas as Trilhas que possuem o Colaborador informado.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("colaborador/{id}")]
        public IActionResult GetByColaboradorId(int id)
        {
            var trilhas = _repository.GetAllTrilhasByColaboradorId(id);
            return Ok(_mapper.Map<IEnumerable<TrilhaDto>>(trilhas));

        }

        // GET: api/trilha/habilidade/4
        /// <summary>
        /// Método responsavel para retornar todas as Trilhas que possuem a Habilidade informada.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("habilidade/{id}")]
        public IActionResult GetByHabilidadeId(int id)
        {
            var trilhas = _repository.GetAllTrilhasByHabilidadeId(id);
            return Ok(_mapper.Map<IEnumerable<TrilhaDto>>(trilhas));

        }

        // POST: api/Trilha
        /// <summary>
        /// Método responsável por adicionar uma nova Trilha.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(TrilhaCreateDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var trilha = _mapper.Map<Trilha>(model);

            _repository.Add(trilha);
            if (_repository.SaveChanges())
            {
                return Created($"/api/trilha/{trilha.Id}", _mapper.Map<TrilhaReturnDto>(trilha));
            }
            return BadRequest("Trilha não cadastrada");
        }

        // PUT: api/trilha/5
        /// <summary>
        /// Método responsável por atualizar uma Trilha.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, TrilhaCreateDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var trilha = _repository.GetTrilhaById(id);
                if (trilha == null) return BadRequest("Trilha não encontrada");
                _mapper.Map(model, trilha);
                var result = _repository.UpdateTrilha(trilha);
                return Ok(result);
            }
            catch(ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // DELETE: api/Trilha/5
        /// <summary>
        /// Método responsável para Remover Trilha.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var trilha = _repository.GetTrilhaById(id);
            if (trilha == null) return BadRequest("Trilha não encontrada");

            try
            {
                _repository.DeleteTrilha(trilha);
                return Ok("Trilha foi removida");
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
