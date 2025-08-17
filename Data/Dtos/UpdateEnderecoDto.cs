using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivroAPI.Data.Dtos
{
    public class UpdateEnderecoDto
    {

        [Required(ErrorMessage = "Logradouro é obrigatorio")]
        public required string Logradouro { get; set; }

        [Required(ErrorMessage = "Numero é obrigatorio")]
        public required int Numero { get; set; }

    }
}
