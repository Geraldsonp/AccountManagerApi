using System;
using System.ComponentModel.DataAnnotations;
using ApplicationLayer;
using ApplicationLayer.Domain.Enums;


namespace AccountManagerAPi.Dtos
{
    public record UpdateClientRequest
    {
        [MaxLength(200)]
        public string? Address { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }

        public Status? Status { get; set; }

        public Gender? Gender { get; set; }

        public int? Age { get; set; }

        public string? Identification { get; set; } = null!;
    }
}
