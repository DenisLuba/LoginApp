using MyLoginApp.Models;
using SQLite;

namespace MyLoginApp.Services.ProductService;

public class ProductService : IProductRepository
{
    public SQLiteAsyncConnection _database;
    public ProductService(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<ProductInfo>().Wait();
    }

    public async Task<bool> AddUpdateProductAsync(ProductInfo productInfo)
         => productInfo.ProductId > 0 
            ? await _database.UpdateAsync(productInfo) > 0 
            : await _database.InsertAsync(productInfo) > 0;

    public async Task<bool> DeleteProductAsync(int productId)
        => await _database.DeleteAsync<ProductInfo>(productId) > 0;

    public async Task<ProductInfo> GetProductByIdAsync(int productId)
        => await _database
        .Table<ProductInfo>()
        .Where(p => p.ProductId == productId)
        .FirstOrDefaultAsync();

    public async Task<IEnumerable<ProductInfo>> GetProductsAsync()
        => await _database.Table<ProductInfo>().ToListAsync();
}
