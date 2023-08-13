using System;
using ApplicationLayer.Domain.Enums;


namespace AccountManagerAPi.Dtos
{
    public record AccountResponse
    {
        public string AccountNumber { get; set; } = null!;

        public AccountType AccountType { get; set; }

        public decimal CurrentBalance { get; set; }

        public Status Status { get; set; }
    }
}
