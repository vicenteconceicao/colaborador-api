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
    [Route("api/[controller]")]
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

        // GET: api/Trilha
        [HttpGet]
        public IActionResult Get()
        {
            var trilhas = _repository.GetAllTrilhas();
            return Ok(_mapper.Map<IEnumerable<TrilhaDto>>(trilhas));
        }

        // GET: api/Trilha/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var trilha = _repository.GetTrilhaById(id);
            if (trilha == null) return BadRequest("Trilha não foi encontrada");

            var trilhaDto = _mapper.Map<TrilhaDto>(trilha);
            return Ok(trilhaDto);
        }

        // GET: api/Trilha/colaborador/4
        [HttpGet("colaborador/{id}")]
        public IActionResult GetByColaboradorId(int id)
        {
            var trilhas = _repository.GetAllTrilhasByColaboradorId(id);
            return Ok(_mapper.Map<IEnumerable<TrilhaDto>>(trilhas));

        }

        // GET: api/Trilha/habilidade/4
        [HttpGet("habilidade/{id}")]
        public IActionResult GetByHabilidadeId(int id)
        {
            var trilhas = _repository.GetAllTrilhasByHabilidadeId(id);
            return Ok(_mapper.Map<IEnumerable<TrilhaDto>>(trilhas));

        }

        // POST: api/Trilha
        [HttpPost]
        public IActionResult Post(TrilhaDto model)
        {
            var trilha = _mapper.Map<Trilha>(model);

            _repository.Add(trilha);
            if (_repository.SaveChanges())
            {
                return Created($"/api/trilha/{model.Id}", _mapper.Map<TrilhaDto>(trilha));
            }
            return BadRequest("Trilha não cadastrada");
        }

        // PUT: api/Trilha/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, TrilhaDto model)
        {
            var trilha = _repository.GetTrilhaById(id);
            if (trilha == null) return BadRequest("Trilha não encontrada");

            _mapper.Map(model, trilha);

            _repository.Update(trilha);
            if (_repository.SaveChanges())
            {
                return Created($"/api/trilha/{model.Id}", _mapper.Map<TrilhaDto>(trilha));
            }
            return BadRequest("Trilha não atualizada");
        }

        // DELETE: api/Trilha/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var trilha = _repository.GetTrilhaById(id);
            if (trilha == null) return BadRequest("Trilha não encontrada");

            _repository.Remove(trilha);
            if (_repository.SaveChanges()) return Ok("Trilha removida");

            return BadRequest("Trilha não removida");
        }
    }
}
