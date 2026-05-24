using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Inventories;

using CommandHandler = ICommandHandler<DeleteInventoryByIdCommand>;

public record DeleteInventoryByIdCommand(int InventoryId);

public class DeleteInventoryByIdCommandHandler(IInventoryRepository inventoryRepository) : CommandHandler
{
    async Task CommandHandler.HandleAsync(DeleteInventoryByIdCommand request)
        => await inventoryRepository.DeleteInventoryByIdAsync(request.InventoryId);
}