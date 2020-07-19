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

namespace estagio_brg.API.Controllers
{
    [Route("api/habilidade")]
    [ApiController]
    public class HabilidadeController : ControllerBase
    {
        private IRepository _repository;
        private IMapper _mapper;
        public HabilidadeController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/habilidade
        /// <summary>
        /// Método responsável para retornar todos as Habilidades.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var habilidades = _repository.GetAllHabilidades();
            return Ok(_mapper.Map<IEnumerable<HabilidadeDto>>(habilidades));
        }

        // GET: api/habilidade/5
        /// <summary>
        /// Método responsável para retornar uma única Habilidade.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var habilidade = _repository.GetHabilidadeById(id);
            if (habilidade == null) return BadRequest("Habilidade não foi encontrada");

            var habilidadeDto = _mapper.Map<HabilidadeDto>(habilidade);

            return Ok(habilidadeDto);
        }

        // GET: api/habilidade/colaborador/4
        /// <summary>
        /// Método responsavel para retornar todas as Habilidade de um Colaborador informado. 
        /// </summary>
        /// <param name="id">Id do Colaborador.</param>
        /// <returns></returns>
        [HttpGet("colaborador/{id}", Name = "GetByColaboradorId")]
        public IActionResult GetByColaboradorId(int id)
        {
            var habilidades = _repository.GetAllHabilidadesByColaboradorId(id);
            return Ok(_mapper.Map<IEnumerable<HabilidadeDto>>(habilidades));

        }

        // POST: api/Habilidade
        /// <summary>
        /// Método responsável por adicionar uma nova Habilidade.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(HabilidadeCreateDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var habilidade = _mapper.Map<Habilidade>(model);

            _repository.Add(habilidade);
            if (_repository.SaveChanges())
            {
                return Created($"/api/habilidade/{habilidade.Id}", _mapper.Map<HabilidadeDto>(habilidade));
            }
            return BadRequest("Habilidade não cadastrada");
        }

        // PUT: api/habilidade/5
        /// <summary>
        /// Método responsável por atualizar uma Habilidade.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, HabilidadeCreateDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var habilidade = _repository.GetHabilidadeById(id);
            if (habilidade == null) return BadRequest("Habilidade não encontrada");

            _mapper.Map(model, habilidade);

            _repository.Update(habilidade);
            if (_repository.SaveChanges())
            {
                return Created($"/api/habilidade/{habilidade.Id}", _mapper.Map<HabilidadeDto>(habilidade));
            }
            return BadRequest("Habilidade não atualizada");
        }

        // DELETE: api/habilidade/5
        /// <summary>
        /// Método responsável para Remover Habilidade.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var habilidade = _repository.GetHabilidadeById(id);
            if (habilidade == null) return BadRequest("Habilidade não encontrada");

            _repository.Remove(habilidade);
            if (_repository.SaveChanges()) return Ok("Habilidade removida");

            return BadRequest("Habilidade não removida");
        }
    }
}
