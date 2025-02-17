using LojaVirtual.FrontWeb.Models;
using LojaVirtual.FrontWeb.Services.Interfaces;
using System.Text;
using System.Text.Json;

namespace LojaVirtual.FrontWeb.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string apiEndpoint = "/api/produtos/";
        private readonly JsonSerializerOptions _options; 
        private ProdutoViewModel produtoVM;
        private IEnumerable<ProdutoViewModel> produtosVM;


        public ProdutoService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<IEnumerable<ProdutoViewModel>> GetAllProdutos()
        {
            var client = _clientFactory.CreateClient("ProdutoApi");
            using (var response = await client.GetAsync(apiEndpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();

                    produtosVM = await JsonSerializer
                        .DeserializeAsync<IEnumerable<ProdutoViewModel>>(apiResponse, _options);
                }
                else {
                    return null;
                }
            }
            return produtosVM;

        }

        public async Task<ProdutoViewModel> FindProdutoById(int id)
        {
            var client = _clientFactory.CreateClient("ProdutoApi");
            using (var response = await client.GetAsync(apiEndpoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();

                    produtoVM = await JsonSerializer
                        .DeserializeAsync<ProdutoViewModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                } 
            }
            return produtoVM;
        }

        public async Task<ProdutoViewModel> CreateProduto(ProdutoViewModel produtoVM)
        {
            var client = _clientFactory.CreateClient("ProdutoApi");
            StringContent content = new StringContent(JsonSerializer.Serialize(produtoVM),
                              Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync(apiEndpoint, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();

                    produtoVM = await JsonSerializer
                        .DeserializeAsync<ProdutoViewModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return produtoVM;
        }

        public async Task<ProdutoViewModel> UpdateProduto(ProdutoViewModel produtoVM)
        {
            var client = _clientFactory.CreateClient("ProdutoApi");
            ProdutoViewModel produtoUpdated = new ProdutoViewModel();

            using (var response = await client.PutAsJsonAsync(apiEndpoint, produtoVM))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();

                    produtoUpdated = await JsonSerializer
                        .DeserializeAsync<ProdutoViewModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return produtoUpdated;
        }

        public async Task<bool> DeleteProdutoById(int id)
        {
            var client = _clientFactory.CreateClient("ProdutoApi");

            using (var response = await client.DeleteAsync(apiEndpoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
