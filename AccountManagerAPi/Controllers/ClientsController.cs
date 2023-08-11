using System;
using Microsoft.AspNetCore.Mvc;


namespace AccountManagerAPi.Controllers
{
    [ApiController]
    public class ClientsController : ControllerBase
    {


        [HttpGet("{clientId}/accounts/{accountNumber}")]
        public async Task<IActionResult> GetAccountAsync(int clientId, int accountNumber)
        {
            throw new NotImplementedException();
            return Ok();
        }

    }
}
