namespace NOM.Domain._Base.Exceptions;

/// <summary>
/// haitc 01/06/2022
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public class ConflictException : ApplicationException
{
    public ConflictException(string message)
        : base("Conflict", message)
    {
    }
}