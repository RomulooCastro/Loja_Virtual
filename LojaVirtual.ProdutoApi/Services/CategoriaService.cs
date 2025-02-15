using AutoMapper;
using LojaVirtual.ProdutoApi.DTOs;
using LojaVirtual.ProdutoApi.Repositories;
using LojaVirtual.ProdutoApi.Models;

namespace LojaVirtual.ProdutoApi.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;


        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaDTO>> GetCategorias()
        {
            var categoriasEntity = await _categoriaRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoriaDTO>>(categoriasEntity);
        }

        public async Task<IEnumerable<CategoriaDTO>> GetCategoriasProdutos()
        {
            var categoriasEntity = await _categoriaRepository.GetCategoriasProdutos();
            return _mapper.Map<IEnumerable<CategoriaDTO>>(categoriasEntity);
        }

        public async Task<CategoriaDTO> GetCategoriaById(int id)
        {
            var categoriaEntity = await _categoriaRepository.GetById(id);
            return _mapper.Map<CategoriaDTO>(categoriaEntity);
        }

        public async Task AddCategoria(CategoriaDTO categoriaDTO)
        {
            var categoriaEntity = _mapper.Map<Categoria>(categoriaDTO);
            await _categoriaRepository.Create(categoriaEntity);
            categoriaDTO.CategoriaId = categoriaEntity.CategoriaId;
        }

        public async Task UpdateCategoria(CategoriaDTO categoriaDTO)
        {
            var categoriaEntity = _mapper.Map<Categoria>(categoriaDTO);
            await _categoriaRepository.Update(categoriaEntity);
        }

        public async Task RemoveCategoria(int id)
        {
            var categoriaEntity = _categoriaRepository.GetById(id).Result;
            await _categoriaRepository.Delete(categoriaEntity.CategoriaId);
        }
    }
}