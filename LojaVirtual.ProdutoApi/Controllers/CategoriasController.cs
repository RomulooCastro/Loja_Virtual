using Microsoft.AspNetCore.Mvc;
using LojaVirtual.ProdutoApi.DTOs;
using LojaVirtual.ProdutoApi.Services;

namespace LojaVirtual.ProdutoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
        {
            var categoriasDto = await _categoriaService.GetCategorias();

            if (categoriasDto is null)
                return NotFound("Categories not found");

            return Ok(categoriasDto);
        }

        [HttpGet("produtos")]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategoriasProducts()
        {
            var CategoriasDTO = await _categoriaService.GetCategoriasProdutos();
            if (CategoriasDTO == null)
            {
                return NotFound("Categories not found");
            }
            return Ok(CategoriasDTO);
        }

        [HttpGet("{id:int}", Name = "GetCategoria")]
        public async Task<ActionResult<CategoriaDTO>> Get(int id)
        {
            var CategoriaDTO = await _categoriaService.GetCategoriaById(id);
            if (CategoriaDTO == null)
            {
                return NotFound("Categoria not found");
            }
            return Ok(CategoriaDTO);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoriaDTO CategoriaDTO)
        {
            if (CategoriaDTO == null)
                return BadRequest("Invalid Data");

            await _categoriaService.AddCategoria(CategoriaDTO);

            return new CreatedAtRouteResult("GetCategoria", new { id = CategoriaDTO.CategoriaId },
                CategoriaDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoriaDTO CategoriaDTO)
        {
            if (id != CategoriaDTO.CategoriaId)
                return BadRequest();

            if (CategoriaDTO is null)
                return BadRequest();

            await _categoriaService.UpdateCategoria(CategoriaDTO);

            return Ok(CategoriaDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoriaDTO>> Delete(int id)
        {
            var CategoriaDTO = await _categoriaService.GetCategoriaById(id);
            if (CategoriaDTO == null)
            {
                return NotFound("Categoria not found");
            }

            await _categoriaService.RemoveCategoria(id);

            return Ok(CategoriaDTO);
        }
    }
}