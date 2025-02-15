﻿namespace LojaVirtual.FrontWeb.Models
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public decimal Price { get; set; }

        public string? Description { get; set; }

        public long Stock { get; set; }

        public string? ImageURL { get; set; }

        public string? CategoriaName { get; set; }

        public int CategoriaId { get; set; }
    }
}
