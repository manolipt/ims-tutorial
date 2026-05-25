using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Products;

using CommandHandler = ICommandHandler<EditProductCommand>;

public record EditProductCommand(Product Product);

public class EditProductCommandHandler(IProductRepository productRepository) : CommandHandler
{
    async Task CommandHandler.HandleAsync(EditProductCommand request)
    {
        await productRepository.UpdateProductAsync(request.Product);
    }
}