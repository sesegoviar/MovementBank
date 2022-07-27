using Bank.ApplicationCore.Entities;
using Bogus;
using Store.ApplicationCore.Entities;
using Store.ApplicationCore.Utils;
using Store.Infrastructure.Persistence.Contexts;

namespace Bank.SharedDatabaseSetup
{
    public static class DatabaseSetup
    {
        public static void SeedData(StoreContext context)
        {
            context.Products.RemoveRange(context.Products);

            var clientIds = 1;
            var fakeClients = new Faker<Client>()
                .RuleFor(o => o.Name, f => $"Client {clientIds}")
                .RuleFor(o => o.Direction, f => $"Description {clientIds}")
                .RuleFor(o => o.Id, f => clientIds++);

            var clients = fakeClients.Generate(1);

            context.AddRange(clients);

            context.SaveChanges();
        }
    }
}