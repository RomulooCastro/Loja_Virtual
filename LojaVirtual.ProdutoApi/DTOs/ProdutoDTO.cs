using LojaVirtual.ProdutoApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LojaVirtual.ProdutoApi.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome Obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Preço Obrigatório")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Descrição Obrigatório")]
        [MinLength(5)]
        [MaxLength(200)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Stock Obrigatório")]
        [Range(1, 9999)]
        public long Stock { get; set; }

        public string? ImageURL { get; set; }
        public string? CategoriaName { get; set; }

        [JsonIgnore]
        public Categoria? Categoria { get; set; }
        public int CategoriaId { get; set; }
    }
}
