namespace IMS.CoreBusiness;

public interface IQueryHandler
{
    
}

public interface IQueryHandler<TResult> : IQueryHandler
{
    Task<TResult> HandeAsync();
}

public interface IQueryHandler<in TQuery, TResult> : IQueryHandler
{
    Task<TResult> HandleAsync(TQuery request);
}