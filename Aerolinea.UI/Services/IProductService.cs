using Aerolinea.Models;

namespace Aerolinea.UI.Services
{
	public interface IProductService
	{
		Task<IEnumerable<Product>> GetAllProduct();
		Task<Product> GetProductDetailas(string id);
		Task SaveProduct(Product product);
		Task DeleteProduct(string id);
	}
}
