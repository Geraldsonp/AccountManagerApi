using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AccountManagerAPi.Dtos;
using ApplicationLayer;
using ApplicationLayer.Domain.Enums;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace AccountManagerAPi.IntegrationTests
{
    public class ClientsControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ClientsControllerTests(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_ReturnsOk()
        {
            var response = await _client.GetAsync("api/clients");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Get_WithId_ReturnsOk()
        {

            var createRequest = new CreateClientRequest
            {
                Name = "John Doe",
                Address = "123 Main St",
                Phone = "555-555-5555",
                Password = "password123",
                Status = Status.Active
            };
            var createRequestJson = JsonConvert.SerializeObject(createRequest);
            var content = new StringContent(createRequestJson, Encoding.UTF8, "application/json");
            var createResponse = await _client.PostAsync("api/clients", content);
            var createdClientJson = await createResponse.Content.ReadAsStringAsync();
            var createdClient = JsonConvert.DeserializeObject<ClientResponse>(createdClientJson);
            createResponse.EnsureSuccessStatusCode();


            var response = await _client.GetAsync($"api/clients/{createdClient.ClientId}");


            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseJson = await response.Content.ReadAsStringAsync();
            var clientResponse = JsonConvert.DeserializeObject<ClientResponse>(responseJson);
            clientResponse.Should().NotBeNull();
            clientResponse.Name.Should().Be(createRequest.Name);
            clientResponse.Phone.Should().Be(createRequest.Phone);
            clientResponse.ClientId.Should().Be(createdClient.ClientId);

        }


        [Fact]
        public async Task Post_ReturnsOk()
        {
            var createRequest = new CreateClientRequest
            {
                Name = "John Doe",
                Address = "123 Main St",
                Phone = "555-555-5555",
                Password = "password123",
                Status = Status.Active
            };

            var json = JsonConvert.SerializeObject(createRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/clients", content);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseJson = await response.Content.ReadAsStringAsync();
            var clientResponse = JsonConvert.DeserializeObject<ClientResponse>(responseJson);
            clientResponse.Should().NotBeNull();
            clientResponse.Name.Should().Be(createRequest.Name);
            clientResponse.Phone.Should().Be(createRequest.Phone);
        }

        [Fact]
        public async Task Put_ReturnsOk()
        {
            var updateRequest = new UpdateClientRequest
            {
                Phone = "555-555-5555",
                Status = Status.Active,
                Address = "Updated Test Address"
            };
            var json = JsonConvert.SerializeObject(updateRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PatchAsync("api/clients/1", content);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseJson = await response.Content.ReadAsStringAsync();
            var clientResponse = JsonConvert.DeserializeObject<ClientResponse>(responseJson);
            clientResponse.Should().NotBeNull();

            clientResponse.Phone.Should().Be(updateRequest.Phone);
            clientResponse.Status.Should().Be(updateRequest.Status);
            clientResponse.Address.Should().Be(updateRequest.Address);
        }
    }
}