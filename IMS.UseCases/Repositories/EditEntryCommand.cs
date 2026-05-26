using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Repositories;

public record EditEntryCommand<T>(T Entry);

internal class EditEntryCommandHandler<T>(IRepository<T> repository) : ICommandHandler<EditEntryCommand<T>>
{
    async Task ICommandHandler<EditEntryCommand<T>>.HandleAsync(EditEntryCommand<T> request)
    {
        await repository.UpdateAsync(request.Entry);
    }
}
