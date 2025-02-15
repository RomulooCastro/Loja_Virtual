using LojaVirtual.ProdutoApi.Models;

namespace LojaVirtual.ProdutoApi.Repositories
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetAll();
        Task<Produto> GetById(int id);
        Task<Produto> Create(Produto categoria);
        Task<Produto> Update(Produto categoria);
        Task<Produto> Delete(int id);
    }
}
