using IMS.CoreBusiness;

namespace IMS.UseCases.Inventories;

public interface IGetInventoryByIdUseCase
{
    Task<Inventory?> ExecuteAsync(int inventoryId);
}