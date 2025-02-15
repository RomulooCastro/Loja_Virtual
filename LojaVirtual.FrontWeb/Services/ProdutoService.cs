using LojaVirtual.FrontWeb.Models;
using LojaVirtual.FrontWeb.Services.Interfaces;
using System.Text.Json;

namespace LojaVirtual.FrontWeb.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string apiEndpoint = "/api/produtos/";
        private readonly JsonSerializerOptions _options; 
        private ProdutoViewModel produtoVM;
        private IEnumerable<ProdutoViewModel> produtoList;


        public ProdutoService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public Task<IEnumerable<ProdutoViewModel>> GetAllProdutos()
        {
            throw new NotImplementedException();
        }

        public Task<ProdutoViewModel> FindProdutoById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProdutoViewModel> CreateProduto(ProdutoViewModel produtoVM)
        {
            throw new NotImplementedException();
        }

        public Task<ProdutoViewModel> UpdateProduto(ProdutoViewModel produtoVM)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProdutoById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
