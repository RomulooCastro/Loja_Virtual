using LojaVirtual.FrontWeb.Models;

namespace LojaVirtual.FrontWeb.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaViewModel>> GetAllCategorias();
    }
}
