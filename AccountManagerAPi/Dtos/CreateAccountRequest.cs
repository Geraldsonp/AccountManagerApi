using System;
using System.ComponentModel.DataAnnotations;
using ApplicationLayer.Domain.Enums;


namespace AccountManagerAPi.Dtos
{
    public class CreateAccountRequest
    {

        public decimal InitialBalance { get; set; } = 0;
        public AccountType AccountType { get; set; }

        [Required(ErrorMessage = "Client Id is required")]
        public int ClientId { get; set; }
    }
}
