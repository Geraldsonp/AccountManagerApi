namespace ApplicationLayer.Domain.Exceptions;

public class DomainException : Exception
{
    public int StatusCode { get; internal set; }
    public DomainException(string message):base(message)
    {
        
    }
}