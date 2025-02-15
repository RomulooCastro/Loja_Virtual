using LojaVirtual.ProdutoApi.Models;

namespace LojaVirtual.ProdutoApi.Repositories
{
    //Interface: Declara os métodos sem implementá-los.
    public interface ICategoriaRepository
    {   //categorias assincronas
        Task<IEnumerable<Categoria>> GetAll();
        Task<IEnumerable<Categoria>> GetCategoriasProdutos();
        Task<Categoria> GetById(int id);
        Task<Categoria> Create(Categoria categoria);
        Task<Categoria> Update(Categoria categoria);
        Task<Categoria> Delete(int id);

    }
}
