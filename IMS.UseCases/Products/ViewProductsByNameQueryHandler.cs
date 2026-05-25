using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Products;

using QueryHandler = IQueryHandler<ViewProductsByNameQuery, IEnumerable<Product>>;

public record ViewProductsByNameQuery(string Name = "");

public class ViewProductsByNameQueryHandler(IProductRepository productRepository) : QueryHandler
{
    async Task<IEnumerable<Product>> QueryHandler.HandleAsync(ViewProductsByNameQuery query)
    {
        return await productRepository.GetProductsByNameAsync(query.Name);
    }
}