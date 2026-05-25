using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Products;

using QueryHandler = IQueryHandler<GetProductByIdQuery, Product?>;

public record GetProductByIdQuery(int ProductId);

internal class GetProductByIdQueryHandler(IProductRepository productRepository) : QueryHandler
{
    async Task<Product?> QueryHandler.HandleAsync(GetProductByIdQuery request)
    {
        return await productRepository.GetProductByIdAsync(request.ProductId);
    }
}