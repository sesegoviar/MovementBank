using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.FunctionalTests.Controllers
{
    public class AccountControllerTest : BaseControllerTests
    {
        public AccountControllerTest(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
        }
        [Fact]
        public async Task GetAccount_ReturnsAllRecords()
        {
            var client = this.GetNewClient();
            var response = await client.GetAsync("/api/Account");
            response.EnsureSuccessStatusCode();

            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<AccountResponse>>(stringResponse).ToList();
            var statusCode = response.StatusCode.ToString();

            Assert.Equal("OK", statusCode);
            Assert.True(result.Count == 3);
        }

        [Fact]
        public async Task PostAccount_ReturnsCreatedAccount()
        {
            var client = this.GetNewClient();

            // Create product

            var request = new CreateAccountRequest
            {
                NumberAccount = "478758",
                TypeAccount = "Ahorro",
                BalanceInitial = 300,
                State = true,

            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response1 = await client.PostAsync("/api/Client", stringContent);
            response1.EnsureSuccessStatusCode();

            var stringResponse1 = await response1.Content.ReadAsStringAsync();
            var createdClient = JsonConvert.DeserializeObject<SingleAccountResponse>(stringResponse1);
            var statusCode1 = response1.StatusCode.ToString();

            Assert.Equal("Created", statusCode1);

            // Get created product

            var response2 = await client.GetAsync($"/api/Account/{createdAccount.Id}");
            response2.EnsureSuccessStatusCode();

            var stringResponse2 = await response2.Content.ReadAsStringAsync();
            var result2 = JsonConvert.DeserializeObject<SingleAccountResponse>(stringResponse2);
            var statusCode2 = response2.StatusCode.ToString();

            Assert.Equal("OK", statusCode2);
            Assert.Equal(createdAccount.Id, result2.Id);
            Assert.Equal(createdAccount.TypeAccount, result2.Account);
            Assert.Equal(createdAccount.NumberAccount, result2.NumberAccount);
            Assert.Equal(createdAccount.State, result2.State);
        }


    }
}
