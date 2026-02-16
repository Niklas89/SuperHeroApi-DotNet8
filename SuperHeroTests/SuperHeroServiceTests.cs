using Microsoft.EntityFrameworkCore;
using SuperHeroAPI_DotNet8.Data;
using SuperHeroAPI_DotNet8.Entities;
using SuperHeroAPI_DotNet8.Services.SuperHeroService;

namespace SuperHeroTests
{
    public class SuperHeroServiceTests
    {
        private SuperHeroService CreateService(string dbName)
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            var context = new DataContext(options);
            return new SuperHeroService(context);
        }

        private SuperHero CreateHero()
        {
            return new SuperHero
            {
                Id = 1,
                FirstName = "Peter",
                LastName = "Parker",
                Name = "Spiderman",
                Place = "New York"
            };
        }

        [Fact]
        public async Task AddHero_Should_Add_Hero_And_Return_List()
        {
            var service = CreateService(nameof(AddHero_Should_Add_Hero_And_Return_List));

            var hero = CreateHero();

            var result = await service.AddHero(hero);

            Assert.Single(result);
            Assert.Equal("Spiderman", result[0].Name);
        }

        [Fact]
        public async Task GetAllHeroes_Should_Return_All_Heroes()
        {
            var service = CreateService(nameof(GetAllHeroes_Should_Return_All_Heroes));

            await service.AddHero(CreateHero());

            var heroes = await service.GetAllHeroes();

            Assert.Single(heroes);
        }

        [Fact]
        public async Task GetSingleHero_Should_Return_Hero_When_Found()
        {
            var service = CreateService(nameof(GetSingleHero_Should_Return_Hero_When_Found));

            await service.AddHero(CreateHero());

            var hero = await service.GetSingleHero(1);

            Assert.NotNull(hero);
            Assert.Equal("Peter", hero!.FirstName);
        }

        [Fact]
        public async Task GetSingleHero_Should_Return_Null_When_NotFound()
        {
            var service = CreateService(nameof(GetSingleHero_Should_Return_Null_When_NotFound));

            var hero = await service.GetSingleHero(99);

            Assert.Null(hero);
        }

        [Fact]
        public async Task UpdateHero_Should_Update_Existing_Hero()
        {
            var service = CreateService(nameof(UpdateHero_Should_Update_Existing_Hero));

            await service.AddHero(CreateHero());

            var updatedHero = new SuperHero
            {
                FirstName = "Bruce",
                LastName = "Wayne",
                Name = "Batman",
                Place = "Gotham"
            };

            var result = await service.UpdateHero(1, updatedHero);

            Assert.NotNull(result);
            Assert.Equal("Batman", result![0].Name);
        }

        [Fact]
        public async Task UpdateHero_Should_Return_Null_When_NotFound()
        {
            var service = CreateService(nameof(UpdateHero_Should_Return_Null_When_NotFound));

            var result = await service.UpdateHero(99, new SuperHero
            {
                Name = "TestHero"
            });

            Assert.Null(result);
        }

        [Fact]
        public async Task DeleteHero_Should_Remove_Hero()
        {
            var service = CreateService(nameof(DeleteHero_Should_Remove_Hero));

            await service.AddHero(CreateHero());

            var result = await service.DeleteHero(1);

            Assert.Empty(result!);
        }

        [Fact]
        public async Task DeleteHero_Should_Return_Null_When_NotFound()
        {
            var service = CreateService(nameof(DeleteHero_Should_Return_Null_When_NotFound));

            var result = await service.DeleteHero(99);

            Assert.Null(result);
        }
    }
}