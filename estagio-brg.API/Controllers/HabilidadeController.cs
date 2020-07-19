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
    public class HabilidadeController : ControllerBase
    {
        private IRepository _repository;
        private IMapper _mapper;
        public HabilidadeController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/Habilidade
        [HttpGet]
        public IActionResult Get()
        {
            var habilidades = _repository.GetAllHabilidades();
            return Ok(_mapper.Map<IEnumerable<HabilidadeDto>>(habilidades));
        }

        // GET: api/Habilidade/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var habilidade = _repository.GetHabilidadeById(id);
            if (habilidade == null) return BadRequest("Habilidade não foi encontrada");

            var habilidadeDto = _mapper.Map<HabilidadeDto>(habilidade);

            return Ok(habilidadeDto);
        }

        // GET: api/Habilidade/colaborador/4
        [HttpGet("colaborador/{id}", Name = "GetByColaboradorId")]
        public IActionResult GetByColaboradorId(int id)
        {
            var habilidades = _repository.GetAllHabilidadesByColaboradorId(id);
            return Ok(_mapper.Map<IEnumerable<HabilidadeDto>>(habilidades));

        }

        // POST: api/Habilidade
        [HttpPost]
        public IActionResult Post(HabilidadeDto model)
        {
            var habilidade = _mapper.Map<Habilidade>(model);

            _repository.Add(habilidade);
            if (_repository.SaveChanges())
            {
                return Created($"/api/habilidade/{model.Id}", _mapper.Map<HabilidadeDto>(habilidade));
            }
            return BadRequest("Habilidade não cadastrada");
        }

        // PUT: api/Habilidade/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, HabilidadeDto model)
        {
            var habilidade = _repository.GetHabilidadeById(id);
            if (habilidade == null) return BadRequest("Habilidade não encontrada");

            _mapper.Map(model, habilidade);

            _repository.Update(habilidade);
            if (_repository.SaveChanges())
            {
                return Created($"/api/habilidade/{model.Id}", _mapper.Map<HabilidadeDto>(habilidade));
            }
            return BadRequest("Habilidade não atualizada");
        }

        // DELETE: api/Habilidade/5
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
