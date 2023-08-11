using ApplicationLayer.Domain;
using ApplicationLayer.Domain.Contracts;

namespace ApplicationLayer;
public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }
    public Task<Cliente> Create(Cliente cliente)
    {
        throw new NotImplementedException();
    }

    public async Task<Cliente> Delete(int id)
    {
        var cliente = await _clientRepository.Get(c => c.ClienteId == id);
        await _clientRepository.Delete(cliente);
        return cliente;
    }

    public async Task<Cliente> Get(int id)
    {
        var cliente = await _clientRepository.Get(c => c.ClienteId == id);
        return cliente;
    }

    public async Task<IEnumerable<Cliente>> GetAll()
    {
        var clientes = await _clientRepository.GetAll(c => true);
        return clientes;
    }

    public Task<Cliente> Update(Cliente cliente)
    {
        throw new NotImplementedException();
    }
}
