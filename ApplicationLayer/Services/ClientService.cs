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
    public async Task<Client> Create(Client client)
    {
        await _clientRepository.Create(client);
        return client;
    }

    public async Task Delete(int id)
    {
        var client = await _clientRepository.Get(c => c.ClientId == id);
        await _clientRepository.Delete(client);
    }

    public async Task<Client> Get(int id)
    {
        var client = await _clientRepository.Get(c => c.ClientId == id);
        return client;
    }

    public async Task<IEnumerable<Client>> GetAll()
    {
        var clients = await _clientRepository.GetAll();
        return clients;
    }

    public async Task<Client> Update(Client client)
    {
        await _clientRepository.Update(client);
        return client;
    }
}
