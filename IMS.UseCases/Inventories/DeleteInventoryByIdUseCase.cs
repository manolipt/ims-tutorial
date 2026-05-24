using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Inventories;

public class DeleteInventoryByIdUseCase(IInventoryRepository inventoryRepository) : IDeleteInventoryByIdUseCase
{
    public async Task ExecuteAsync(int inventoryId)
    {
        await inventoryRepository.DeleteInventoryByIdAsync(inventoryId);
    }
}