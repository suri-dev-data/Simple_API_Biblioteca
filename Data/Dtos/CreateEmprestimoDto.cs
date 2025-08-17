using LivroAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivroAPI.Data.Dtos
{
    public class CreateEmprestimoDto
    {

        [Required(ErrorMessage = "Dia de Devolução é obrigatorio")]
        public required DateTime diaDeDevolucao { get; set; }
        [Required(ErrorMessage = "Livro é obrigatorio")]
        public int LivroId { get; set; }
        [Required(ErrorMessage = "Pessoa é obrigatorio")]
        public int PessoaId { get; set; }

        public DateTime diaDoEmprestimo { get; set; } = DateTime.Now;


    }
}
