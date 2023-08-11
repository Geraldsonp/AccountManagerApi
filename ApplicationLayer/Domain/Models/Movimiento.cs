namespace ApplicationLayer.Domain;

public partial class Movimiento
{
    public int MovimientoId { get; set; }

    public int? NumeroCuenta { get; set; }

    public DateTime Fecha { get; set; }

    public string TipoMovimiento { get; set; } = null!;

    public decimal Valor { get; set; }

    public decimal Saldo { get; set; }

    public virtual Cuenta? NumeroCuentaNavigation { get; set; }
}
