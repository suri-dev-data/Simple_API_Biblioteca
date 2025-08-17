using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivroAPI.Models
{
    public class Endereco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Logradouro é obrigatorio")]
        public required string Logradouro { get; set; }

        [Required(ErrorMessage = "Logradouro é obrigatorio")]
        public required int Numero { get; set; }

    }
}
