using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Products;

using QueryHandler = IQueryHandler<GetProductsByNameQuery, IEnumerable<Product>>;

public record GetProductsByNameQuery(string Name = "");

internal class GetProductsByNameQueryHandler(IProductRepository productRepository) : QueryHandler
{
    async Task<IEnumerable<Product>> QueryHandler.HandleAsync(GetProductsByNameQuery query)
    {
        return await productRepository.GetProductsByNameAsync(query.Name);
    }
}