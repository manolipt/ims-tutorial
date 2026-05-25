using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Products;

using QueryHandler = IQueryHandler<GetProductByIdQuery, Product?>;

public record GetProductByIdQuery(int ProductId);

public class GetProductByIdQueryHandler(IProductRepository productRepository) : QueryHandler
{
    async Task<Product?> QueryHandler.HandleAsync(GetProductByIdQuery request)
        => await productRepository.GetProductByIdAsync(request.ProductId);
}