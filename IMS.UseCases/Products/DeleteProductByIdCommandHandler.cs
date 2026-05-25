using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Products;

using CommandHandler = ICommandHandler<DeleteProductByIdCommand>;

public record DeleteProductByIdCommand(int ProductId);

public class DeleteProductByIdCommandHandler(IProductRepository productRepository) : CommandHandler
{
    async Task CommandHandler.HandleAsync(DeleteProductByIdCommand request)
        => await productRepository.DeleteProductByIdAsync(request.ProductId);
}