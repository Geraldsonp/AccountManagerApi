using System.ComponentModel.DataAnnotations;
using ApplicationLayer.Domain.Enums;


namespace AccountManagerAPi.Dtos
{
    public record UpdateAccountRequest
    {
        [Required]
        public Status Status { get; set; }
    }
}
