using System.ComponentModel.DataAnnotations;
using ApplicationLayer;
using ApplicationLayer.Domain.Enums;

namespace AccountManagerAPi.Dtos;
public record class CreateClientRequest
{
    [Required, MaxLength(100)]
    public string Nombre { get; set; } = null!;

    [Required]
    public Gender Genero { get; set; }

    [Required, Range(15, 100)]
    public int Edad { get; set; }

    [Required, MaxLength(20)]
    public string Identificacion { get; set; } = null!;
    [Required, MaxLength(200)]
    public string Direccion { get; set; } = null!;

    [Required, MaxLength(20)]
    public string Telefono { get; set; } = null!;
    [Required, MaxLength(20)]
    public string Contrasena { get; set; } = null!;
    [Required]
    public Status Estado { get; set; } = Status.Active;
}
