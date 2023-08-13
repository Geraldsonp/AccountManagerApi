using ApplicationLayer.Domain;
using ApplicationLayer.Domain.Contracts;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repos;
public class ClientRepository : CrudBaseRepo<Client>, IClientRepository
{
    public ClientRepository(AccountsManagerDbContext context) : base(context)
    {

    }
}
