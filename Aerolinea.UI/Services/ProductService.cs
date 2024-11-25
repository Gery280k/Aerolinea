using Aerolinea.Models;
using System.Text;
using System.Text.Json;

namespace Aerolinea.UI.Services
{
	public class ProductService : IProductService
	{
		private readonly HttpClient _httpClient;
		public ProductService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task DeleteProduct(string id)
			
		{
			await _httpClient.DeleteAsync($"api/product/{id}");
		}

		public async Task<IEnumerable<Product>> GetAllProduct()
		{
			return await JsonSerializer.DeserializeAsync<IEnumerable<Product>>
			(await _httpClient.GetStreamAsync($"api/product"), 
			new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
		}

		public async Task<Product> GetProductDetailas(string id)
		{
			return await JsonSerializer.DeserializeAsync<Product>
			(await _httpClient.GetStreamAsync($"api/product/{id}"),
			new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
		}

		public async Task SaveProduct(Product product)
		{
			var productJson = new StringContent(JsonSerializer.Serialize(product), 
				Encoding.UTF8, "application/json");

			if (string.IsNullOrEmpty(product.Id))
				await _httpClient.PostAsync("api/product", productJson);
			else
				await _httpClient.PutAsync($"api/product/{product.Id}", productJson);
		}
	}
}
