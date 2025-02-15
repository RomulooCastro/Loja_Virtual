using Microsoft.AspNetCore.Mvc;
using LojaVirtual.ProdutoApi.DTOs;
using LojaVirtual.ProdutoApi.Services;

namespace LojaVirtual.ProdutoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
        [HttpGet]

        //actionResult para retornar o status , ex: notFound = 404 , ok = 200
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> Get()
        {
            var produtosDto = await _produtoService.GetProdutos();
            if (produtosDto == null)
            {
                return NotFound("Produtos not found");
            }
            return Ok(produtosDto);
        }

        [HttpGet("{id}", Name = "GetProduto")]
        public async Task<ActionResult<ProdutoDTO>> Get(int id)
        {
            var produtoDto = await _produtoService.GetProdutoById(id);
            if (produtoDto == null)
            {
                return NotFound("Produto not found");
            }
            return Ok(produtoDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProdutoDTO produtoDto)
        {
            if (produtoDto == null)
                return BadRequest("Data Invalid");

            await _produtoService.AddProduto(produtoDto);

            return new CreatedAtRouteResult("GetProduto",
                new { id = produtoDto.Id }, produtoDto);
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] ProdutoDTO produtoDto)
        {
            if (produtoDto == null)
                return BadRequest("Data invalid");

            await _produtoService.UpdateProduto(produtoDto);
            return Ok(produtoDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoDTO>> Delete(int id)
        {
            var produtoDto = await _produtoService.GetProdutoById(id);

            if (produtoDto == null)
            {
                return NotFound("Produto not found");
            }

            await _produtoService.RemoveProduto(id);

            return Ok(produtoDto);
        }
    }
}