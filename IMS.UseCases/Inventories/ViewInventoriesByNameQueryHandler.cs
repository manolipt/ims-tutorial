using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Inventories;

using QueryHandler = IQueryHandler<ViewInventoriesByNameRequest, ViewInventoriesByNameResponse>;

public record ViewInventoriesByNameRequest(string Name = "");
public record ViewInventoriesByNameResponse(IEnumerable<Inventory> Inventories);

public class ViewInventoriesByNameQueryHandler(IInventoryRepository inventoryRepository) : QueryHandler
{
    async Task<ViewInventoriesByNameResponse> QueryHandler.HandleAsync(ViewInventoriesByNameRequest request)
        => new(await inventoryRepository.GetInventoriesByNameAsync(request.Name));
}
