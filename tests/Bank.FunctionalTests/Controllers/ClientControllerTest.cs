using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.FunctionalTests.Controllers
{

    public class ClientControllerTest : BaseControllerTests
    {
        public ClientControllerTest(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
        }
        [Fact]
        public async Task GetClient_ReturnsAllRecords()
        {
            var client = this.GetNewClient();
            var response = await client.GetAsync("/api/Client");
            response.EnsureSuccessStatusCode();

            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<ClientResponse>>(stringResponse).ToList();
            var statusCode = response.StatusCode.ToString();

            Assert.Equal("OK", statusCode);
            Assert.True(result.Count == 10);
        }

        [Fact]
        public async Task PostClient_ReturnsCreatedClient()
        {
            var client = this.GetNewClient();

            // Create product

            var request = new CreateClientRequest
            {
                Name = "José Lema",
                Genre = "masculino",
                Age = 30,
                Identification = "1103998959",
                Direction = "Otavalo sn y principal",
                Phono = "098254785",
                ClientUser = "jose_lema",
                Password = "1234",
                State = true
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response1 = await client.PostAsync("/api/Client", stringContent);
            response1.EnsureSuccessStatusCode();

            var stringResponse1 = await response1.Content.ReadAsStringAsync();
            var createdClient = JsonConvert.DeserializeObject<SingleClientResponse>(stringResponse1);
            var statusCode1 = response1.StatusCode.ToString();

            Assert.Equal("Created", statusCode1);

            // Get created product

            var response2 = await client.GetAsync($"/api/Client/{createdClient.Id}");
            response2.EnsureSuccessStatusCode();

            var stringResponse2 = await response2.Content.ReadAsStringAsync();
            var result2 = JsonConvert.DeserializeObject<SingleClientResponse>(stringResponse2);
            var statusCode2 = response2.StatusCode.ToString();

            Assert.Equal("OK", statusCode2);
            Assert.Equal(createdClient.Name, result2.Name);
            Assert.Equal(createdClient.Identification, result2.Identification);
            Assert.Equal(createdClient.Genre, result2.Genre);
            Assert.Equal(createdClient.Age, result2.Age);
        }

       
    }

}
