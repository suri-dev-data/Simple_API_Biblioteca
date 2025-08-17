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

namespace LivroAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : ControllerBase
    {
        private LivroContext _context;
        private IMapper _mapper;

        public LivroController(LivroContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Add books to Database
        /// </summary>
        /// <param name="livroDto">Object with all parameters necessity</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">In case of succeded action</response>
        [HttpPost]
        public IActionResult AdicionaLivro([FromBody] CreateLivroDto livroDto)
        {
            Livro livro = _mapper.Map<Livro>(livroDto);
            _context.livros.Add(livro);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaLivroPorID), new { id = livro.Id }, livro);
        }

        [HttpGet]
        public IEnumerable<ReadLivroDto> RecuperaLivro([FromQuery] int skip = 0,
            [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadLivroDto>>(_context.livros.Skip(skip).Take(take).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaLivroPorID(int id)
        {
            var livro = _context.livros.FirstOrDefault(livros => livros.Id == id);
            if (livro == null) return NotFound();
            var livroDto = _mapper.Map<ReadLivroDto>(livro);
            return Ok(livroDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaLivro(int id,
           [FromBody] UpdateLivroDto livroDto)
        {
            var livro = _context.livros.FirstOrDefault(livros => livros.Id == id);
            if (livro == null) return NotFound();
            _mapper.Map(livroDto,livro);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpPatch("{id}")]
        public IActionResult AtualizaLivroParcial(int id,
            JsonPatchDocument<UpdateLivroDto> patch)
        {
            var livro = _context.livros.FirstOrDefault(livros => livros.Id == id);
            if (livro == null) return NotFound();
            
            var livroToUpdate = _mapper.Map<UpdateLivroDto>(livro);

            patch.ApplyTo(livroToUpdate, ModelState);

            if (!TryValidateModel(livroToUpdate))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(livroToUpdate, livro);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult AtualizaLivroParcial(int id)
        {
            var livro = _context.livros.FirstOrDefault(livros => livros.Id == id);
            if (livro == null) return NotFound();
            _context.Remove(livro);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
