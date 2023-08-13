using System;
using AccountManagerAPi.Dtos;
using ApplicationLayer.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;


namespace AccountManagerAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;


        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;

        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionRequest transactionRequest)
        {
            var transaction = await _transactionService.CreateTransactionAsync(transactionRequest.AccountNumber, transactionRequest.Amount);
            return Ok(transaction);
        }


        [HttpGet("/Accounts/{accountNumber}/Transactions/{transactionId}")]
        public async Task<IActionResult> GetTransaction([FromRoute] string accountNumber, [FromRoute] int transactionId)
        {
            var transaction = await _transactionService.GetTransactionAsync(transactionId, accountNumber);
            return Ok(transaction);
        }

        [HttpGet("/Accounts/{accountNumber}/Transactions")]
        public async Task<IActionResult> GetTransactions([FromRoute] string accountNumber)
        {
            var transactions = await _transactionService.GetTransactionsAsync(accountNumber);
            return Ok(transactions);
        }

        [HttpDelete("/Accounts/{accountNumber}/Transactions/{transactionId}")]
        public async Task<IActionResult> DeleteTransaction([FromRoute] string accountNumber, [FromRoute] int transactionId)
        {
            await _transactionService.DeleteTransactionAsync(transactionId, accountNumber);
            return Ok();
        }


    }
}
