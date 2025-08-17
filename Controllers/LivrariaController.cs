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

namespace LivrariaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivrariaController : ControllerBase
    {
        private LivroContext _context;
        private IMapper _mapper;

        public LivrariaController(LivroContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Add books to Database
        /// </summary>
        /// <param name="livrariaDto">Object with all parameters necessity</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">In case of succeded action</response>
        [HttpPost]
        public IActionResult AdicionaLivraria([FromBody] CreateLivrariaDto livrariaDto)
        {
            Livraria livraria = _mapper.Map<Livraria>(livrariaDto);
            _context.livrarias.Add(livraria);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaLivrariaPorID), new { id = livraria.Id }, livraria);
        }

        [HttpGet]
        public IEnumerable<ReadLivrariaDto> RecuperaLivraria([FromQuery] int skip = 0,
            [FromQuery] int take = 50)
        { 
            var listaDeLivrarias = _mapper.Map<List<ReadLivrariaDto>>(_context.livrarias.Skip(skip).Take(take).ToList());
            return listaDeLivrarias;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaLivrariaPorID(int id)
        {
            var livraria = _context.livrarias.FirstOrDefault(livrarias => livrarias.Id == id);
            if (livraria == null) return NotFound();
            var livrariaDto = _mapper.Map<ReadLivrariaDto>(livraria);
            return Ok(livrariaDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaLivraria(int id,
           [FromBody] UpdateLivrariaDto livrariaDto)
        {
            var livraria = _context.livrarias.FirstOrDefault(livrarias => livrarias.Id == id);
            if (livraria == null) return NotFound();
            _mapper.Map(livrariaDto,livraria);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpPatch("{id}")]
        public IActionResult AtualizaLivrariaParcial(int id,
            JsonPatchDocument<UpdateLivrariaDto> patch)
        {
            var livraria = _context.livrarias.FirstOrDefault(livrarias => livrarias.Id == id);
            if (livraria == null) return NotFound();
            
            var livrariaToUpdate = _mapper.Map<UpdateLivrariaDto>(livraria);

            patch.ApplyTo(livrariaToUpdate, ModelState);

            if (!TryValidateModel(livrariaToUpdate))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(livrariaToUpdate, livraria);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult AtualizaLivrariaParcial(int id)
        {
            var livraria = _context.livrarias.FirstOrDefault(livrarias => livrarias.Id == id);
            if (livraria == null) return NotFound();
            _context.Remove(livraria);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
