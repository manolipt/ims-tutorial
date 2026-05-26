namespace IMS.UseCases.PluginInterfaces;

public interface IRepository<T>
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetByNameAsync(string name);
    Task AddAsync(T entry);
    Task UpdateAsync(T entry);
    Task DeleteByIdAsync(int id);
}