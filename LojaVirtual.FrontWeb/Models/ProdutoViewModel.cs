using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.FrontWeb.Models
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public long Stock { get; set; }
        [Required]
        public string? ImageURL { get; set; }
        public string? CategoriaName { get; set; }
        [Display(Name = "Categorias")]
        public int CategoriaId { get; set; }
    }
}
