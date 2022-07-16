using System;

namespace NOM.Domain._Base.Abstractions.Messaging;

/// <summary>
/// haitc 02/06/2022
/// </summary>
/// <typeparam name="TResponse"></typeparam>
public interface IIdempotentCommand<out TResponse> : ICommand<TResponse>
{
    Guid RequestId { get; set; }
}