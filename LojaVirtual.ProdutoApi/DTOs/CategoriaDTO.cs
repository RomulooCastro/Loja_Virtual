using LojaVirtual.ProdutoApi.Models;
using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.ProdutoApi.DTOs
{
    public class CategoriaDTO
    {
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Nome Obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]

        public string? Name { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
}
