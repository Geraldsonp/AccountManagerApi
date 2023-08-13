using ApplicationLayer.Domain;

namespace ApplicationLayer;
public interface IClientService
{
    Task<Client> Create(Client cliente);
    Task<Client> Update(Client cliente);
    Task Delete(int id);
    Task<Client> Get(int id);
    Task<IEnumerable<Client>> GetAll();
}
