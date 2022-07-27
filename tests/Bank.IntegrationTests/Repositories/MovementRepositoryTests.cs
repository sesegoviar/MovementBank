using AutoMapper;
using Bank.Infrastructure.Persistence.Repositories;
using Bank.ApplicationCore.DTOs;
using Store.ApplicationCore.Exceptions;
using Store.ApplicationCore.Mappings;
using Bank.Infrastructure.Persistence.Repositories;
using Xunit;
using Store.IntegrationTests;

namespace Bank.IntegrationTests.Repositories
{
    public class MovementRepositoryTests : IClassFixture<SharedDatabaseFixture>
    {
        private readonly IMapper _mapper;
        private SharedDatabaseFixture Fixture { get; }

        public MovementRepositoryTests(SharedDatabaseFixture fixture)
        {
            Fixture = fixture;

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GeneralProfile>();
            });

            _mapper = configuration.CreateMapper();
        }

        [Fact]
        public void GetMovements_ReturnsAllMovements()
        {
            using (var context = Fixture.CreateContext())
            {
                var repository = new MovementRepository(context, _mapper);

                var movements = repository.GetMovements();

                Assert.Equal(0, movements.Count);
            }
        }

        [Fact]
        public void GetMovementById_MovementDoesntExist_ThrowsNotFoundException()
        {
            using (var context = Fixture.CreateContext())
            {
                var repository = new MovementRepository(context, _mapper);
                var movementId = 1;

                Assert.Throws<NotFoundException>(() => repository.GetMovementById(movementId));
            }
        }
        
    }
}