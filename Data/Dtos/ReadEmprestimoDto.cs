using LivroAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivroAPI.Data.Dtos
{
    public class ReadEmprestimoDto
    {
        public required DateTime diaDeDevolucao { get; set; }
        public int LivroId { get; set; }
        public int PessoaId { get; set; }
        public DateTime diaDoEmprestimo { get; set; }
    }
}
