using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.FunctionalTests.Controllers
{

    public class MovementControllerTest : BaseControllerTests
    {
        public MovementControllerTest(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
        }
        [Fact]
        public async Task GetMovement_ReturnsAllRecords()
        {
            var client = this.GetNewClient();
            var response = await client.GetAsync("/api/Movement");
            response.EnsureSuccessStatusCode();

            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<MovementResponse>>(stringResponse).ToList();
            var statusCode = response.StatusCode.ToString();

            Assert.Equal("OK", statusCode);
            Assert.True(result.Count == 3);
        }

        [Fact]
        public async Task PostMovement_ReturnsCreatedMovement()
        {
            var client = this.GetNewClient();

            // Create product

            var request = new CreateMovementRequest
            {
                
                Value = 200,
                TypeMovement = "Ahorro",
                Date = "2022-07-24",

            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response1 = await client.PostAsync("/api/Movement", stringContent);
            response1.EnsureSuccessStatusCode();

            var stringResponse1 = await response1.Content.ReadAsStringAsync();
            var createdMovement = JsonConvert.DeserializeObject<SingleMovementResponse>(stringResponse1);
            var statusCode1 = response1.StatusCode.ToString();

            Assert.Equal("Created", statusCode1);

            // Get created product

            var response2 = await movement.GetAsync($"/api/Movement/{createdMovement.Id}");
            response2.EnsureSuccessStatusCode();

            var stringResponse2 = await response2.Content.ReadAsStringAsync();
            var result2 = JsonConvert.DeserializeObject<SingleMovementResponse>(stringResponse2);
            var statusCode2 = response2.StatusCode.ToString();

            Assert.Equal("OK", statusCode2);
            Assert.Equal(createdMovement.Value, result2.Vale);
            Assert.Equal(createdMovement.TypeMovement, result2.TypeMovement);
            Assert.Equal(createdMovement.NumberState, result2.NumberState);
    
        }


    
    }
}
