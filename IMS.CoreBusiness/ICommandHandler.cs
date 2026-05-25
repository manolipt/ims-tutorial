namespace IMS.CoreBusiness;

public interface ICommandHandler
{
}

public interface ICommandHandler<in TCommand> : ICommandHandler
{
    Task HandleAsync(TCommand request);
}

public interface ICommandHandler<in TCommand, TResponse> : ICommandHandler
{
    Task<TResponse> HandleAsync(TCommand request);
}