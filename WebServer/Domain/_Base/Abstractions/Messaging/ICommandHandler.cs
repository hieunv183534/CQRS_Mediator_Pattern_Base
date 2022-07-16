using MediatR;

namespace NOM.Domain._Base.Abstractions.Messaging;

/// <summary>
/// haitc 02/06/2022
/// </summary>
/// <typeparam name="TResponse"></typeparam>
public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
{
}