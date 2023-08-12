using System;
using AccountManagerAPi.Dtos;
using ApplicationLayer;
using ApplicationLayer.Domain;
using Mapster;
using Microsoft.AspNetCore.Mvc;


namespace AccountManagerAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateClientRequest createClientRequest)
        {
            var client = createClientRequest.Adapt<Client>();
            await _clientService.Create(client);
            return Ok(client);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
