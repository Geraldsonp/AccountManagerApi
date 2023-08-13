using System;
using System.ComponentModel.DataAnnotations;
using ApplicationLayer.Domain.Enums;


namespace AccountManagerAPi.Dtos
{
    public record UpdateClientRequest
    {
        [MaxLength(20)]
        public string? Password { get; set; }

        [MaxLength(200)]
        public string? Address { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }

        public Status? Status { get; set; }
    }
}
