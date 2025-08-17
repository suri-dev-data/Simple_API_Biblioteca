using LivroAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace LivroAPI.Data.Dtos
{
    public class ReadLivroDto
    {
        public required string titulo { get; set; }
        public required string genero { get; set; }
        public int paginas { get; set; }
        public DateTime horaDaConsulta {  get; set; } = DateTime.Now;
        public virtual ICollection<ReadEmprestimoDto> Emprestimos { get; set; }

    }
}
