namespace LojaVirtual.ProdutoApi.Models;

public class Produto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public  decimal Price { get; set; }
    public  string? Description { get; set; }
    public long Stock { get; set; }
    public string? ImageURL { get; set; }


    public Categoria? Categoria { get; set; }
    public int CategoriaId { get; set; }

}

