using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Products;

using CommandHandler = ICommandHandler<AddProductCommand>;

public record AddProductCommand(Product Product);

internal class AddProductCommandHandler(IProductRepository productRepository) : CommandHandler
{
    async Task CommandHandler.HandleAsync(AddProductCommand request)
    {
        await productRepository.AddProductAsync(request.Product);
    }
}