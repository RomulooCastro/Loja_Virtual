namespace LojaVirtual.ProdutoApi.Models;

public class Categoria
{

    public int CategoriaId { get; set; }
    public string? Name { get; set; }

    public ICollection<Produto> Produtos { get; set; }

}
