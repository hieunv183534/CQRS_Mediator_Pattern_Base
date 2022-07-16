namespace NOM.Domain._Base.Exceptions;

/// <summary>
/// haitc 01/06/2022
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public sealed class BadRequestException : ApplicationException
{
    public BadRequestException(string message)
        : base("Bad Request", message)
    {
    }
}