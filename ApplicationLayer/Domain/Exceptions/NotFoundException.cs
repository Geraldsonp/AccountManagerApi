namespace ApplicationLayer.Domain.Exceptions;

public class NotFoundException : DomainException
{
    
    public NotFoundException(string entityName, int id) : base($"{entityName} with id: {id}, was not found")
    {
        StatusCode = 404;
    }
    
    public NotFoundException(string entityName, string id) : base($"{entityName} with id: {id}, was not found")
    {
        StatusCode = 404;
    }
}