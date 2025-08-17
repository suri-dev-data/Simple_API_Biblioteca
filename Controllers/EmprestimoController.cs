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

namespace EmprestimoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmprestimoController : ControllerBase
    {
        private LivroContext _context;
        private IMapper _mapper;

        public EmprestimoController(LivroContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Add books to Database
        /// </summary>
        /// <param name="emprestimoDto">Object with all parameters necessity</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">In case of succeded action</response>
        [HttpPost]
        public IActionResult AdicionaEmprestimo([FromBody] CreateEmprestimoDto emprestimoDto)
        {
            Emprestimo emprestimo = _mapper.Map<Emprestimo>(emprestimoDto);
            _context.emprestimos.Add(emprestimo);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaEmprestimoPorID), new { livroId = emprestimo.LivroId, pessoaId = emprestimo.PessoaId }, emprestimo);
        }

        [HttpGet]
        public IEnumerable<ReadEmprestimoDto> RecuperaEmprestimo([FromQuery] int skip = 0,
            [FromQuery] int take = 50)
        {
            var listaDeEmprestimos = _mapper.Map<List<ReadEmprestimoDto>>(_context.emprestimos.Skip(skip).Take(take).ToList());
            return listaDeEmprestimos;
        }

        [HttpGet("{livroId}/{pessoaId}")]
        public IActionResult RecuperaEmprestimoPorID(int livroId,int pessoaId)
        {
            var emprestimo = _context.emprestimos.FirstOrDefault(emprestimos => 
            emprestimos.LivroId == livroId && emprestimos.PessoaId == pessoaId);

            if (emprestimo == null) return NotFound();
            var emprestimoDto = _mapper.Map<ReadEmprestimoDto>(emprestimo);
            return Ok(emprestimoDto);
        }

        [HttpPut("{livroId}/{pessoaId}")]
        public IActionResult AtualizaEmprestimo(int livroId,int pessoaId,
           [FromBody] UpdateEmprestimoDto emprestimoDto)
        {
            var emprestimo = _context.emprestimos.FirstOrDefault(emprestimos =>
            emprestimos.LivroId == livroId && emprestimos.PessoaId == pessoaId);
            if (emprestimo == null) return NotFound();
            _mapper.Map(emprestimoDto, emprestimo);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpPatch("{livroId}/{pessoaId}")]
        public IActionResult AtualizaEmprestimoParcial(int livroId, int pessoaId,
            JsonPatchDocument<UpdateEmprestimoDto> patch)
        {
            var emprestimo = _context.emprestimos.FirstOrDefault(emprestimos =>
            emprestimos.LivroId == livroId && emprestimos.PessoaId == pessoaId);
            if (emprestimo == null) return NotFound();

            var emprestimoToUpdate = _mapper.Map<UpdateEmprestimoDto>(emprestimo);

            patch.ApplyTo(emprestimoToUpdate, ModelState);

            if (!TryValidateModel(emprestimoToUpdate))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(emprestimoToUpdate, emprestimo);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{livroId}/{pessoaId}")]
        public IActionResult AtualizaEmprestimoParcial(int livroId, int pessoaId)
        {
            var emprestimo = _context.emprestimos.FirstOrDefault(emprestimos =>
                emprestimos.LivroId == livroId && emprestimos.PessoaId == pessoaId);
            if (emprestimo == null) return NotFound();
            _context.Remove(emprestimo);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
