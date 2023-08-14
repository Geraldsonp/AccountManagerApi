namespace ApplicationLayer.Domain.Contracts;

public interface IClientRepository : ICrud<Client>
{
    Task<bool> DoesClientExist(int clientId);
}