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

            return CreatedAtAction(nameof(ClientsController.GetAccountAsync), new { accountNumber = account.NumeroCuenta, clientId = account.ClienteId }, account);
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
        public async Task<IActionResult> GetAccountsAsync(int clientId)
        {
            var accounts = await _accountService.GetAccountsAsync();

            return Ok(accounts);
        }

    }
}
