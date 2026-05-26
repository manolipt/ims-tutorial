using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Repositories;

public record GetByIdQuery<T>(int Id);

internal class GetByIdQueryHandler<T>(IRepository<T> repository) : IQueryHandler<GetByIdQuery<T>, T?>
{
    async Task<T?> IQueryHandler<GetByIdQuery<T>, T?>.HandleAsync(GetByIdQuery<T> request)
    {
        return await repository.GetByIdAsync(request.Id);
    }
}