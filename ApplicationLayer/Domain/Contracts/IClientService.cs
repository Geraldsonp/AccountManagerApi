using ApplicationLayer.Domain;

namespace ApplicationLayer;
public interface IClientService
{
    Task<Cliente> Create(Cliente cliente);
    Task<Cliente> Update(Cliente cliente);
    Task<Cliente> Delete(int id);
    Task<Cliente> Get(int id);
    Task<IEnumerable<Cliente>> GetAll();
}
