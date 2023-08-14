using ApplicationLayer.Domain;
using ApplicationLayer.Domain.Contracts;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repos;
public class ClientRepository : CrudBaseRepo<Client>, IClientRepository
{
    private readonly AccountsManagerDbContext context;

    public ClientRepository(AccountsManagerDbContext context) : base(context)
    {
        this.context = context;
    }

    public async Task<bool> DoesClientExist(int clientId)
    {
        return await context.Clients.AnyAsync(c => c.ClientId == clientId);
    }
}
