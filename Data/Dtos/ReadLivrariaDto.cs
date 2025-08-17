using LivroAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivroAPI.Data.Dtos
{
    public class ReadLivrariaDto
    {
        public int Id { get; set; }

        public required string Nome { get; set; }
        public ReadEnderecoDto Endereco { get; set; }
        public virtual ICollection<ReadLivroDto> Livros { get; set; }

    }
}
