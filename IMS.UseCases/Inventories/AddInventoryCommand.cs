using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Inventories;

using CommandHandler = ICommandHandler<AddInventoryCommand>;

public record AddInventoryCommand(Inventory Inventory);

internal class AddInventoryCommandHandler(IInventoryRepository inventoryRepository)
    : CommandHandler
{
    async Task CommandHandler.HandleAsync(AddInventoryCommand request)
    {
        await inventoryRepository.AddInventoryAsync(request.Inventory);
    }
}