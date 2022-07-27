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
{     public class AccountRepositoryTest : IClassFixture<SharedDatabaseFixture>
    {
        private readonly IMapper _mapper;
        private SharedDatabaseFixture Fixture { get; }

        public AccountRepositoryTest(SharedDatabaseFixture fixture)
        {
            Fixture = fixture;

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GeneralProfile>();
            });

            _mapper = configuration.CreateMapper();
        }

        [Fact]
        public void GetAccounts_ReturnsAccounts()
        {
            using (var context = Fixture.CreateContext())
            {
                var repository = new AccountRepository(context, _mapper);

                var accounts = repository.GetAccounts();

                Assert.Equal(0, accounts.Count());
            }
        }

        [Fact]
        public void GetAccountById_AccountDoesntExist_ThrowsNotFoundException()
        {
            using (var context = Fixture.CreateContext())
            {
                var repository = new AccountRepository(context, _mapper);
                var accountId = 1;

                Assert.Throws<NotFoundException>(() => repository.GetAccountById(accountId));
            }
        }
    }
}
