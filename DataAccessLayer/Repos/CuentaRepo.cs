using ApplicationLayer.Domain;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repos;

public class CuentaRepo : CrudBaseRepo<Cuenta>
{
    public CuentaRepo(AccountMngDbContext context) : base(context)
    {
    }
}