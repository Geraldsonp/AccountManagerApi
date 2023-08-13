using System;
using System.ComponentModel.DataAnnotations;
using ApplicationLayer.Domain.Enums;


namespace AccountManagerAPi.Dtos
{
    public class CreateAccountRequest
    {
        [Required(ErrorMessage = "Account Number is required")]
        public string AccountNumber { get; set; } = null!;

        public decimal InitialBalance { get; set; } = 0;


        [Required(ErrorMessage = "Account Type is required")]
        public AccountType AccountType { get; set; }


        [Required(ErrorMessage = "Client Id is required")]
        public int ClientId { get; set; }

        public Status Status { get; set; } = Status.Active;
    }
}
