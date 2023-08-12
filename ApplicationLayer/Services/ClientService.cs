using ApplicationLayer.Domain;
using ApplicationLayer.Domain.Contracts;

namespace ApplicationLayer.Services;
public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }
    public Task<Client> Create(Client cliente)
    {
        throw new NotImplementedException();
    }

    public async Task<Client> Delete(int id)
    {
        var cliente = await _clientRepository.Get(c => c.ClientId == id);
        await _clientRepository.Delete(cliente);
        return cliente;
    }

    public async Task<Client> Get(int id)
    {
        var cliente = await _clientRepository.Get(c => c.ClientId == id);
        return cliente;
    }

    public async Task<IEnumerable<Client>> GetAll()
    {
        var clientes = await _clientRepository.GetAll(c => true);
        return clientes;
    }

    public Task<Client> Update(Client cliente)
    {
        throw new NotImplementedException();
    }
}
