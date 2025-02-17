using LojaVirtual.FrontWeb.Models;
using LojaVirtual.FrontWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LojaVirtual.FrontWeb.Controllers
{
    public class ProdutosController : Controller    
    {
        private readonly IProdutoService _produtoService;
        private readonly ICategoriaService _categoriaService;

        public ProdutosController(IProdutoService produtoService,
                                 ICategoriaService categoriaService)
        {
            _produtoService = produtoService;
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoViewModel>>> Index()
        {
            var resultado = await _produtoService.GetAllProdutos();

            if (resultado is null)
                return View("Error");

            return View(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduto()
        {
            ViewBag.CategoriaId = new SelectList(await
                 _categoriaService.GetAllCategorias(), "CategoriaId", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduto(ProdutoViewModel produtoVM)
        {
            if (ModelState.IsValid)
            {
                var resultado = await _produtoService.CreateProduto(produtoVM);

                if (resultado != null)
                    return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.CategoriaId = new SelectList(await
                                     _categoriaService.GetAllCategorias(), "CategoriaId", "Name");
            }
            return View(produtoVM);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduto(int id)
        {
            ViewBag.CategoriaId = new SelectList(await
                               _categoriaService.GetAllCategorias(), "CategoriaId", "Name");

            var resultado = await _produtoService.FindProdutoById(id);

            if (resultado is null)
                return View("Error");

            return View("UpdateProduto",resultado);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduto(ProdutoViewModel produtoVM)
        {
            if (ModelState.IsValid)
            {
                var resultado = await _produtoService.UpdateProduto(produtoVM);

                if (resultado is not null)
                    return RedirectToAction(nameof(Index));
            }
            return View(produtoVM);
        }

        [HttpGet]
        public async Task<ActionResult<ProdutoViewModel>> DeleteProduto(int id)
        {
            var resultado = await _produtoService.FindProdutoById(id);

            if (resultado is null)
                return View("Error");

            return View(resultado);
        }

        [HttpPost(), ActionName("DeleteProduto")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultado = await _produtoService.DeleteProdutoById(id);

            if (!resultado)
                return View("Error");

            return RedirectToAction("Index");
        }
    }
}
