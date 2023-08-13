using System.ComponentModel.DataAnnotations;
using ApplicationLayer;
using ApplicationLayer.Domain.Enums;

namespace AccountManagerAPi.Dtos;
public record class CreateClientRequest
{
    [Required, MaxLength(100)]
    public string Name { get; set; } = null!;

    [Required]
    public Gender Gender { get; set; }

    [Required, Range(15, 100)]
    public int Age { get; set; }

    [Required, MaxLength(20)]
    public string Identification { get; set; } = null!;
    [Required, MaxLength(200)]
    public string Address { get; set; } = null!;

    [Required, MaxLength(20)]
    public string Phone { get; set; } = null!;
    [Required, MaxLength(20)]
    public string Password { get; set; } = null!;
    [Required]
    public Status Status { get; set; } = Status.Active;
}
