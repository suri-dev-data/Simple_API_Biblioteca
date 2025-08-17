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

namespace EnderecoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private LivroContext _context;
        private IMapper _mapper;

        public EnderecoController(LivroContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Add books to Database
        /// </summary>
        /// <param name="enderecoDto">Object with all parameters necessity</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">In case of succeded action</response>
        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaEnderecoPorID), new { id = endereco.Id }, endereco);
        }

        [HttpGet]
        public IEnumerable<ReadEnderecoDto> RecuperaEndereco([FromQuery] int skip = 0,
            [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadEnderecoDto>>(_context.enderecos.Skip(skip).Take(take).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecoPorID(int id)
        {
            var endereco = _context.enderecos.FirstOrDefault(enderecos => enderecos.Id == id);
            if (endereco == null) return NotFound();
            var EnderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
            return Ok(EnderecoDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id,
           [FromBody] UpdateEnderecoDto EnderecoDto)
        {
            var endereco = _context.enderecos.FirstOrDefault(enderecos => enderecos.Id == id);
            if (endereco == null) return NotFound();
            _mapper.Map(EnderecoDto,endereco);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpPatch("{id}")]
        public IActionResult AtualizaEnderecoParcial(int id,
            JsonPatchDocument<UpdateEnderecoDto> patch)
        {
            var endereco = _context.enderecos.FirstOrDefault(enderecos => enderecos.Id == id);
            if (endereco == null) return NotFound();
            
            var enderecoToUpdate = _mapper.Map<UpdateEnderecoDto>(endereco);

            patch.ApplyTo(enderecoToUpdate, ModelState);

            if (!TryValidateModel(enderecoToUpdate))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(enderecoToUpdate, endereco);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult AtualizaEnderecoParcial(int id)
        {
            var endereco = _context.enderecos.FirstOrDefault(enderecos => enderecos.Id == id);
            if (endereco == null) return NotFound();
            _context.Remove(endereco);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
