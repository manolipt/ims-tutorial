using IMS.CoreBusiness;

namespace IMS.UseCases.PluginInterfaces;

public interface IInventoryRepository
{
    Task<Inventory?> GetInventoryByIdAsync(int inventoryId);
    Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name);
    Task AddInventoryAsync(Inventory inventory);
    Task UpdateInventoryAsync(Inventory inventory);
}