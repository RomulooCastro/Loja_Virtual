using LojaVirtual.ProdutoApi.DTOs;

namespace LojaVirtual.ProdutoApi.Services;

public interface IProdutoService
{
    Task<IEnumerable<ProdutoDTO>> GetProdutos();

    Task<ProdutoDTO> GetProdutoById(int id);

    Task AddProduto(ProdutoDTO produtoDTO);

    Task UpdateProduto(ProdutoDTO produtoDTO);

    Task RemoveProduto(int id);
}