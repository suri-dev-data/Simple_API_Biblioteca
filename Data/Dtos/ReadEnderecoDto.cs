using LivroAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace LivroAPI.Data.Dtos
{
    public class ReadEnderecoDto
    {
        public required string Logradouro { get; set; }
        public required int Numero { get; set; }
    }
}
