using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivroAPI.Data.Dtos
{
    public class CreateLivrariaDto
    {

        [Required(ErrorMessage = "Nome é obrigatorio")]
        public required string Nome { get; set; }

        public int EnderecoId { get; set; }


    }
}
