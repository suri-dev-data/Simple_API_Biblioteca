using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivroAPI.Data.Dtos
{
    public class UpdateEmprestimoDto
    {

        [Required(ErrorMessage = "Dia de Devolução é obrigatorio")]
        public required DateTime diaDeDevolucao { get; set; }
        [Required(ErrorMessage = "Livro é obrigatorio")]
        public int LivroId { get; set; }
        [Required(ErrorMessage = "Pessoa é obrigatorio")]
        public int PessoaId { get; set; }

        [Required(ErrorMessage = "Dia de Emprestimo é obrigatorio")]
        public DateTime diaDoEmprestimo { get; set; } = DateTime.Now;

    }
}
