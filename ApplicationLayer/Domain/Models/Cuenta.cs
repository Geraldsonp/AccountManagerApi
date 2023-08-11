using ApplicationLayer.Domain.Enums;

namespace ApplicationLayer.Domain;

public class Cuenta
{

    public int NumeroCuenta { get; set; }

    public int ClienteId { get; set; }

    public string TipoCuenta { get; set; } = null!;

    public decimal SaldoInicial { get; set; }

    public string Estado { get; set; } = AccountStatus.Active.ToString();

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
}
