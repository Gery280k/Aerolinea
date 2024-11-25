
using Aerolinea.Models;

namespace Aerolinea.API.Repositories
{
	public interface IProductCollection
	{
		Task InsertProduct(Product product);
		Task UpdateProduct(Product product);
		Task DeleteProduct(string id);

		Task<List<Product>> GetAllProducts();
		Task<Product> GetProductById(string id);
	}
}
