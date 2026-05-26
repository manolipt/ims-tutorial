using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory;

public class ProductRepository : IRepository<Product>
{
    private readonly List<Product> _products =
    [
        new() { ProductId = 1, ProductName = "Bike", Quantity = 10, Price = 150 },
        new() { ProductId = 2, ProductName = "Car", Quantity = 10, Price = 2000 }
    ];
    
    public Task<Product?> GetByIdAsync(int id) => GetProductByIdAsync(id);

    public Task<IEnumerable<Product>> GetByNameAsync(string name) => GetProductsByNameAsync(name);

    public Task AddAsync(Product entry) => AddProductAsync(entry);

    public Task UpdateAsync(Product entry) => UpdateProductAsync(entry);

    public Task DeleteByIdAsync(int id) => DeleteProductByIdAsync(id);

    private Task<Product?> GetProductByIdAsync(int productId)
        => Task.FromResult((Product?)
            _products
                .FirstOrDefault(p => p.ProductId == productId)
                ?.Clone());

    private async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_products);

        return _products.Where(p => p.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase));
    }

    private Task AddProductAsync(Product product)
    {
        // Enforce uniqueness of Product name
        if (_products.Any(p =>
                p.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)))
            return Task.CompletedTask;

        product.ProductId = _products.Max(p => p.ProductId) + 1;
        _products.Add(product);

        return Task.CompletedTask;
    }

    private Task UpdateProductAsync(Product product)
    {
        // Enforce uniqueness of Product name
        if (_products.Any(p =>
                p.ProductId != product.ProductId &&
                p.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)))
            return Task.CompletedTask;

        var productToUpdate = _products.FirstOrDefault(p => p.ProductId == product.ProductId);

        if (productToUpdate is null) return Task.CompletedTask;

        productToUpdate.ProductName = product.ProductName;
        productToUpdate.Price = product.Price;
        productToUpdate.Quantity = product.Quantity;
        return Task.CompletedTask;
    }
    
    private Task DeleteProductByIdAsync(int productId)
    {
        _products.RemoveAll(p => p.ProductId == productId);
        return Task.CompletedTask;
    }
}