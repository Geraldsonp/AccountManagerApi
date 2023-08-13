using System;
using AccountManagerAPi.Dtos;
using ApplicationLayer.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;


namespace AccountManagerAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;


        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;

        }

        [HttpPost]
        public async Task<IActionResult> CreateAccountAsync([FromBody] CreateAccountRequest request)
        {
            var account = await _accountService.CreateAccountAsync(request.InitialBalance, request.AccountType, request.ClientId);
            var accountReponse = account.Adapt<AccountResponse>();
            return CreatedAtAction("GetClientAccount", new { clientId = account.ClientId, accountNumber = account.AccountNumber }, accountReponse);
        }

        [HttpPatch("{accountNumber}")]
        public async Task<IActionResult> UpdateAccountStatusAsync(string accountNumber, [FromBody] UpdateAccountRequest request)
        {
            var account = await _accountService.UpdateAccountStatusAsync(request.Status, accountNumber);
            var accountReponse = account.Adapt<AccountResponse>();
            return Ok(accountReponse);
        }

        [HttpGet("/Clients/{clientId}/accounts/{accountNumber}")]
        [ActionName("GetClientAccount")]
        public async Task<IActionResult> GetClientAccountAsync(int clientId, string accountNumber)
        {
            var account = await _accountService.GetAccountByClientAsync(accountNumber, clientId);
            var accountReponse = account.Adapt<AccountResponse>();
            return Ok(accountReponse);
        }

        [HttpGet("/Clients/{clientId}/accounts")]
        public async Task<IActionResult> GetClientAccountsAsync(int clientId)
        {
            var accounts = await _accountService.GetAccountsByClientAsync(clientId);
            var accountsReponse = accounts.Adapt<List<AccountResponse>>();
            return Ok(accountsReponse);
        }


        //method only available for admin users 
        [HttpGet("{accountNumber}")]
        public async Task<IActionResult> GetAccountAsync(string accountNumber)
        {
            var account = await _accountService.GetAccountAsync(accountNumber);
            var accountReponse = account.Adapt<AccountResponse>();
            return Ok(accountReponse);
        }

        //method only available for admin users
        [HttpGet]
        public async Task<IActionResult> GetAccountsAsync()
        {
            var accounts = await _accountService.GetAccountsAsync();
            var accountsReponse = accounts.Adapt<List<AccountResponse>>();
            return Ok(accountsReponse);
        }

    }
}
