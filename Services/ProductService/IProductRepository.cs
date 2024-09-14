using MyLoginApp.Models;

namespace MyLoginApp.Services.ProductService;

public interface IProductRepository
{
    Task<bool> AddUpdateProductAsync(ProductInfo productInfo);
    Task<bool> DeleteProductAsync(int productId);
    Task<ProductInfo> GetProductByIdAsync(int productId);
    Task<IEnumerable<ProductInfo>> GetProductsAsync();
}
