using ApplicationLayer.Domain;
using ApplicationLayer.Domain.Contracts;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repos;
public class ClientRepository : CrudBaseRepo<Cliente>, IClientRepository
{
    public ClientRepository(AccountMngDbContext context) : base(context)
    {

    }
}
