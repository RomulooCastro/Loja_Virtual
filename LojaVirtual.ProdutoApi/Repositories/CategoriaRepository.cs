using LojaVirtual.ProdutoApi.Context;
using LojaVirtual.ProdutoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.ProdutoApi.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;
        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        //BUSCA TODOS
        public async Task<IEnumerable<Categoria>> GetAll()
        {
           return await _context.Categorias.ToListAsync(); // em produção nao é recomendado , pois pode retornar milhoes de categorias...
        }

        // BUSCA CATEGORIA PRODUTOS
        public async Task<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            return await _context.Categorias.Include(c => c.Produtos).ToListAsync();
        }

        // BUSCA POR ID 
        public async Task<Categoria> GetById(int id)
        {
            return await _context.Categorias.Where(c => c.CategoriaId == id).FirstOrDefaultAsync();
        }

        // CRIAR
        public async Task<Categoria> Create(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        // ATUALIZAR
        public async Task<Categoria> Update(Categoria categoria)
        {
            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return categoria;
        }

        // DELETAR
        public async Task<Categoria> Delete(int id)
        {
           var categoria = await GetById(id);
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }


    }
}
