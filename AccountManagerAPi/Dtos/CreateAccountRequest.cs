using System;
using System.ComponentModel.DataAnnotations;
using ApplicationLayer.Domain.Enums;


namespace AccountManagerAPi.Dtos
{
    public class CreateAccountRequest
    {

        public decimal InitialBalance { get; set; } = 0
        public AccountType AccountType { get; set; }

        [Required("Account must belong to a client")]
        public int ClientId { get; set; }
    }
}
