using Bank.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Store.ApplicationCore.Entities;

namespace Store.Infrastructure.Persistence.Contexts
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        //public DbSet<Person> Person { get; set; }

        public DbSet<Client> Client { get; set; }

        public DbSet<Account> Account { get; set; }
        public DbSet<Movement> Movement { get; set; }
        
    }
}