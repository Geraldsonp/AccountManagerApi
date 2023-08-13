using System;
using System.ComponentModel.DataAnnotations;


namespace AccountManagerAPi.Dtos
{
    public record CreateTransactionRequest
    {

        [Required]
        public string AccountNumber { get; set; } = null!;
        public decimal Amount { get; set; }
    }
}
