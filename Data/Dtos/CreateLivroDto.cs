using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivroAPI.Data.Dtos
{
    public class CreateLivroDto
    {

        [Required(ErrorMessage = "Titulo é obrigatorio")]
        public required string titulo { get; set; }
        [Required(ErrorMessage = "Genero é obrigatorio")]
        [StringLength(50, ErrorMessage = "O tamanho do genero não pode exceder 50 caracteres")]
        public required string genero { get; set; }

        [Required(ErrorMessage = "Numero de Paginas é obrigatorio")]
        [Range(1, 1000, ErrorMessage = "A quantidade de Paginas deve ter entre 1 e 1000")]
        public int paginas { get; set; }

        [Required(ErrorMessage = "Id da Livraria é obrigatorio")]
        public int LivrariaId { get; set; }

    }
}
