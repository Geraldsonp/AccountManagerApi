using ApplicationLayer.Domain.Enums;
using ApplicationLayer.Domain.Models;

namespace ApplicationLayer.Domain;

public class Client : Person
{
    public int ClientId { get; set; }

    public string Password { get; set; } = null!;

    public Status Status { get; set; }
    public virtual IEnumerable<Account> Accounts { get; set; } = new List<Account>();

}
