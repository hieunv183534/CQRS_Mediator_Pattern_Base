using MediatR;

namespace NOM.Domain._Base.Abstractions.Messaging;

/// <summary>
/// haitc 02/06/2022
/// </summary>
/// <typeparam name="TResponse"></typeparam>
public interface IQuery<out TResponse> : IRequest<TResponse>
{
}