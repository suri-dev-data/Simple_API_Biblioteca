using LivroAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace LivroAPI.Data.Dtos
{
    public class ReadPessoaDto
    {
        public int Id { get; set; }

        public required string Nome { get; set; }
        public ReadEnderecoDto Endereco { get; set; }
        public virtual ICollection<ReadEmprestimoDto> Emprestimos { get; set; }


    }
}
