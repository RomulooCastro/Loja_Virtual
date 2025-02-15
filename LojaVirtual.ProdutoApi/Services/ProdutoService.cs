using AutoMapper;
using LojaVirtual.ProdutoApi.DTOs;
using LojaVirtual.ProdutoApi.Repositories;
using LojaVirtual.ProdutoApi.Models;

namespace LojaVirtual.ProdutoApi.Services;

public class ProdutoService : IProdutoService
{
    private readonly IMapper _mapper;
    private IProdutoRepository _produtoRepository;

    public ProdutoService(IMapper mapper, IProdutoRepository produtoRepository)
    {
        _mapper = mapper;
        _produtoRepository = produtoRepository;
    }

    public async Task<IEnumerable<ProdutoDTO>> GetProdutos()
    {
        var produtosEntity = await _produtoRepository.GetAll();
        return _mapper.Map<IEnumerable<ProdutoDTO>>(produtosEntity);
    }

    public async Task<ProdutoDTO> GetProdutoById(int id)
    {
        var produtoEntity = await _produtoRepository.GetById(id);
        return _mapper.Map<ProdutoDTO>(produtoEntity);
    }

    public async Task AddProduto(ProdutoDTO produtoDTO)
    {
        var produtoEntity = _mapper.Map<Produto>(produtoDTO);
        await _produtoRepository.Create(produtoEntity);
        produtoDTO.Id = produtoEntity.Id;
    }

    public async Task UpdateProduto(ProdutoDTO produtoDTO)
    {
        var categoryEntity = _mapper.Map<Produto>(produtoDTO);
        await _produtoRepository.Update(categoryEntity);
    }

    public async Task RemoveProduto(int id)
    {
        var produtoEntity = await _produtoRepository.GetById(id);
        await _produtoRepository.Delete(produtoEntity.Id);
    }
}