using System;
using AccountManagerAPi.Dtos;
using ApplicationLayer;
using ApplicationLayer.Domain;
using Mapster;
using Microsoft.AspNetCore.Mvc;


namespace AccountManagerAPi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var clients = await _clientService.GetAll();
            var clientResponses = clients.Adapt<IEnumerable<ClientResponse>>();
            return Ok(clientResponses);
        }

        [HttpGet("{clientId}")]
        public async Task<IActionResult> Get(int clientId)
        {
            var client = await _clientService.Get(clientId);
            var clientResponse = client.Adapt<ClientResponse>();
            return Ok(clientResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateClientRequest createClientRequest)
        {
            var client = createClientRequest.Adapt<Client>();
            await _clientService.Create(client);
            var clientResponse = client.Adapt<ClientResponse>();
            return Ok(clientResponse);
        }

        [HttpPatch("{clientId}")]
        public async Task<IActionResult> Put(int clientId, UpdateClientRequest updateRequest)
        {
            var client = await _clientService.Get(clientId);
            client = updateRequest.Adapt(client);
            _ = await _clientService.Update(client);
            var clientResponse = client.Adapt<ClientResponse>();
            return Ok(clientResponse);
        }

        [HttpDelete("{clientId}")]
        public async Task<IActionResult> Delete(int clientId)
        {
            await _clientService.Delete(clientId);
            return NoContent();
        }
    }
}
