using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Repositories;

public record DeleteByIdCommand<T>(int Id);

internal class DeleteByIdCommandHandler<T>(IRepository<T> repository) : ICommandHandler<DeleteByIdCommand<T>>
{
    async Task ICommandHandler<DeleteByIdCommand<T>>.HandleAsync(DeleteByIdCommand<T> request)
    {
        await repository.DeleteByIdAsync(request.Id);
    }
}