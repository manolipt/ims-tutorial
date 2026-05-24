using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Inventories;

using CommandHandler = ICommandHandler<EditInventoryCommand>;

public record EditInventoryCommand(Inventory Inventory);

public class EditInventoryCommandHandler(IInventoryRepository inventoryRepository) : CommandHandler
{
    async Task CommandHandler.HandleAsync(EditInventoryCommand request)
        => await inventoryRepository.UpdateInventoryAsync(request.Inventory);
}