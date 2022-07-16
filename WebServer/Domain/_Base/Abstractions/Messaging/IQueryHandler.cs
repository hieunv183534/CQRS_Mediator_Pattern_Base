using MediatR;

namespace NOM.Domain._Base.Abstractions.Messaging;

/// <summary>
/// haitc 02/06/2022
/// </summary>
/// <typeparam name="TResponse"></typeparam>
public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
{
}