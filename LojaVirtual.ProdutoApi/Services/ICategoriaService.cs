using LojaVirtual.ProdutoApi.DTOs;
namespace LojaVirtual.ProdutoApi.Services;


public interface ICategoriaService
{
    Task<IEnumerable<CategoriaDTO>> GetCategorias();

    Task<IEnumerable<CategoriaDTO>> GetCategoriasProdutos();

    Task<CategoriaDTO> GetCategoriaById(int id);

    Task AddCategoria(CategoriaDTO categoriaDTO);

    Task UpdateCategoria(CategoriaDTO categoriaDTO);

    Task RemoveCategoria(int id);
}