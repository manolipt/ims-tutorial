using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Inventories;

using QueryHandler = IQueryHandler<GetInventoryByIdRequest, GetInventoryByIdResponse>;

public record GetInventoryByIdRequest(int InventoryId);

public record GetInventoryByIdResponse(Inventory? Inventory);

public class GetInventoryByIdQueryHandler(IInventoryRepository inventoryRepository) : QueryHandler
{
    async Task<GetInventoryByIdResponse> QueryHandler.HandleAsync(GetInventoryByIdRequest request)
        => new(await inventoryRepository.GetInventoryByIdAsync(request.InventoryId));
}