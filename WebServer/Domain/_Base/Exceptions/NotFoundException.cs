namespace NOM.Domain._Base.Exceptions;

/// <summary>
/// haitc 01/06/2022
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public sealed class NotFoundException : ApplicationException
{
    public NotFoundException(string message)
        : base("Not Found", message)
    {
    }
}