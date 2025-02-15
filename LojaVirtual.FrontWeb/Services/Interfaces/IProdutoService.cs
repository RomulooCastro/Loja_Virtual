using LojaVirtual.FrontWeb.Models;

namespace LojaVirtual.FrontWeb.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoViewModel>> GetAllProdutos();

        Task<ProdutoViewModel> FindProdutoById(int id);

        Task<ProdutoViewModel> CreateProduto(ProdutoViewModel produtoVM);

        Task<ProdutoViewModel> UpdateProduto(ProdutoViewModel produtoVM);

        Task<bool> DeleteProdutoById(int id);
    }
}
