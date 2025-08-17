using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivroAPI.Models
{
    public class Emprestimo
    {

        [Required(ErrorMessage = "Dia de Devolução é obrigatorio")]
        public required DateTime diaDeDevolucao { get; set; }

        public int LivroId { get; set; }

        public virtual Livro Livro{ get; set; }

        public int PessoaId { get; set; }

        public virtual Pessoa Pessoa { get; set; }

[Required(ErrorMessage = "Dia de Emprestimo é obrigatorio")]
        public DateTime diaDoEmprestimo { get; set; } = DateTime.Now;

    }
}
