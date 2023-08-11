using System;
using AccountManagerAPi.Dtos;
using ApplicationLayer.Services;
using Microsoft.AspNetCore.Mvc;


namespace AccountManagerAPi.Controllers
{
    [ApiController]
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

            return CreatedAtAction(nameof(GetClientAccountAsync), new { accountNumber = account.NumeroCuenta, clientId = account.ClienteId }, account);
        }

        [HttpGet("/clients/{clientId}/accounts/{accountNumber}")]
        public async Task<IActionResult> GetClientAccountAsync(int clientId, int accountNumber)
        {
            var account = await _accountService.GetAccountByClientAsync(accountNumber, clientId);
            return Ok(account);
        }

        [HttpGet("/clients/{clientId}/accounts")]
        public async Task<IActionResult> GetClientAccountsAsync(int clientId)
        {
            var accounts = await _accountService.GetAccountsByClientAsync(clientId);

            return Ok(accounts);
        }


        //method only available for admin users 
        [HttpGet("{accountNumber}")]
        public async Task<IActionResult> GetAccountAsync(int accountNumber)
        {
            var account = await _accountService.GetAccountAsync(accountNumber);
            return Ok(account);
        }

        //method only available for admin users
        [HttpGet]
        public async Task<IActionResult> GetAccountsAsync()
        {
            var accounts = await _accountService.GetAccountsAsync();

            return Ok(accounts);
        }

    }
}
