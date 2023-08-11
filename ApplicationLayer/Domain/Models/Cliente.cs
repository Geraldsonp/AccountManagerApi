namespace ApplicationLayer.Domain;

public class Cliente : Persona
{
    public int ClienteId { get; set; }

    public string Contrasena { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public virtual Persona? Persona { get; set; }
}
