using AutoMapper;
using Bank.Infrastructure.Persistence.Repositories;
using Store.ApplicationCore.Exceptions;
using Store.ApplicationCore.Mappings;
using Store.IntegrationTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Bank.IntegrationTests.Repositories
{
    public class ClientRepositoryTest : IClassFixture<SharedDatabaseFixture>
    {
        private readonly IMapper _mapper;
        private SharedDatabaseFixture Fixture { get; }

        public ClientRepositoryTest(SharedDatabaseFixture fixture)
        {
            Fixture = fixture;

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GeneralProfile>();
            });

            _mapper = configuration.CreateMapper();
        }

        [Fact]
        public void GetClients_ReturnsClients()
        {
            using (var context = Fixture.CreateContext())
            {
                var repository = new ClientRepository(context, _mapper);

                var clients = repository.GetClients();

                Assert.Equal(0, clients.Count);
            }
        }

        [Fact]
        public void GetClientById_ClientDoesntExist_ThrowsNotFoundException()
        {
            using (var context = Fixture.CreateContext())
            {
                var repository = new ClientRepository(context, _mapper);
                var clientId = 1;

                Assert.Throws<NotFoundException>(() => repository.GetClientById(clientId));
            }
        }
    }

}
