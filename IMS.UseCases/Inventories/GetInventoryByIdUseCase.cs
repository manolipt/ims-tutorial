using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Inventories;

public class GetInventoryByIdUseCase(IInventoryRepository inventoryRepository) : IGetInventoryByIdUseCase
{
    public async Task<Inventory?> ExecuteAsync(int inventoryId)
    {
        return await inventoryRepository.GetInventoryByIdAsync(inventoryId);
    }
}