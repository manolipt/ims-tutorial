using IMS.CoreBusiness;
using Microsoft.Extensions.DependencyInjection;

namespace IMS.UseCases.Products;

public static class ServiceCollectionEx
{
    public static void AddProductFeatures(this IServiceCollection services)
    {
        services.AddQueryHandler<GetProductByIdQuery, Product?, GetProductByIdQueryHandler>();
        services.AddQueryHandler<GetProductsByNameQuery, IEnumerable<Product>, GetProductsByNameQueryHandler>();

        services.AddCommandHandler<AddProductCommand, AddProductCommandHandler>();
        services.AddCommandHandler<EditProductCommand, EditProductCommandHandler>();
        services.AddCommandHandler<DeleteProductByIdCommand, DeleteProductByIdCommandHandler>();
    }
}