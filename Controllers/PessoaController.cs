using AutoMapper;
using LivroAPI.Data;
using LivroAPI.Data.Dtos;
using LivroAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace PessoaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private LivroContext _context;
        private IMapper _mapper;

        public PessoaController(LivroContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Add books to Database
        /// </summary>
        /// <param name="pessoaDto">Object with all parameters necessity</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">In case of succeded action</response>
        [HttpPost]
        public IActionResult AdicionaPessoa([FromBody] CreatePessoaDto pessoaDto)
        {
            Pessoa pessoa = _mapper.Map<Pessoa>(pessoaDto);
            _context.pessoas.Add(pessoa);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaPessoaPorID), new { id = pessoa.Id }, pessoa);
        }

        [HttpGet]
        public IEnumerable<ReadPessoaDto> RecuperaPessoa([FromQuery] int skip = 0,
            [FromQuery] int take = 50)
        { 
            var listaDePessoas = _mapper.Map<List<ReadPessoaDto>>(_context.pessoas.Skip(skip).Take(take).ToList());
            return listaDePessoas;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaPessoaPorID(int id)
        {
            var pessoa = _context.pessoas.FirstOrDefault(pessoas => pessoas.Id == id);
            if (pessoa == null) return NotFound();
            var pessoaDto = _mapper.Map<ReadPessoaDto>(pessoa);
            return Ok(pessoaDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaPessoa(int id,
           [FromBody] UpdatePessoaDto pessoaDto)
        {
            var pessoa = _context.pessoas.FirstOrDefault(pessoas => pessoas.Id == id);
            if (pessoa == null) return NotFound();
            _mapper.Map(pessoaDto,pessoa);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpPatch("{id}")]
        public IActionResult AtualizaPessoaParcial(int id,
            JsonPatchDocument<UpdatePessoaDto> patch)
        {
            var pessoa = _context.pessoas.FirstOrDefault(pessoas => pessoas.Id == id);
            if (pessoa == null) return NotFound();
            
            var pessoaToUpdate = _mapper.Map<UpdatePessoaDto>(pessoa);

            patch.ApplyTo(pessoaToUpdate, ModelState);

            if (!TryValidateModel(pessoaToUpdate))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(pessoaToUpdate, pessoa);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult AtualizaPessoaParcial(int id)
        {
            var pessoa = _context.pessoas.FirstOrDefault(pessoas => pessoas.Id == id);
            if (pessoa == null) return NotFound();
            _context.Remove(pessoa);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
