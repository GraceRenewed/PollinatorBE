using Xunit;
using Moq;
using PollinatorBE.Interfaces;
using PollinatorBE.Models;
using PollinatorBE.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PollinatorBE.TestPollinator
{
    public class PollinatorServicesTest
    {
        [Fact]
        public async Task GetAllPollinatorsAsync_ReturnsPollinators()
        {
            // Arrange
            var mockRepo = new Mock<IPollinatorRepository>();
            var expectedPollinators = new List<Pollinator>
            {
                new Pollinator { Id = "1", Name = "Bee", Description = "Test Description" },
                new Pollinator { Id = "2", Name = "Butterfly", Description = "Test Description" }
            };
            mockRepo.Setup(repo => repo.GetAllPollinatorsAsync()).ReturnsAsync(expectedPollinators);

            var service = new PollinatorServices(mockRepo.Object);

            // Act
            var result = await service.GetAllPollinatorsAsync();

            // Assert
            Assert.Equal("1", result[0].Id);
            Assert.Equal("Bee", result[0].Name);
        }

        [Fact]
        public async Task GetPollinatorByIdAsync_ReturnsPollinator()
        {
            // Arrange
            var mockRepo = new Mock<IPollinatorRepository>();
            var expectedPollinator = new Pollinator
            {
                Id = "1", Name = "Bee", Description = "Test Description"
            };
            mockRepo.Setup(repo => repo.GetPollinatorByIdAsync("1")).ReturnsAsync(expectedPollinator);

            var service = new PollinatorServices(mockRepo.Object);

            // Act
            var result = await service.GetPollinatorByIdAsync("1");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Bee", result.Name);
        }

        [Fact]
        public async Task GelPollinatorsByGardenIdAsync_ReturnsPollinators()
        {
            // Arrange
            var mockRepo = new Mock<IPollinatorRepository>();
            var expectedPollinators = new List<Pollinator>
            {
                new Pollinator { Id = "1", Name = "Bee", Description = "Test Description" },
                new Pollinator { Id = "2", Name = "Butterfly", Description = "Test Description" }
            };
            mockRepo.Setup(repo => repo.GetPollinatorsByGardenIdAsync("garden001"))
                    .ReturnsAsync(expectedPollinators);
            var service = new PollinatorServices(mockRepo.Object);
            
            // Act
            var result = await service.GetPollinatorsByGardenIdAsync("garden001");
            
            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Bee", result[0].Name);
        }

        [Fact]
        public async Task CreatePollinatorAsync_ReturnsCreatedPollinator()
        {
            // Arrange
            var mockPollinator = new Pollinator
            {
                Id = "poll050",
                Name = "Moth",
                UserProfileUid = "user001",
                Description = "Test Description"
            };

            var mockRepo = new Mock<IPollinatorRepository>();
            mockRepo.Setup(repo => repo.CreatePollinatorAsync(It.IsAny<Pollinator>()))
                    .ReturnsAsync((Pollinator p) => p);

            var repo = mockRepo.Object;

            // Act
            var result = await repo.CreatePollinatorAsync(mockPollinator);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Moth", result.Name);
            Assert.Equal("user001", result.UserProfileUid);
        }

        [Fact]
        public async Task UpdatePollinatorAsync_ReturnUpdatedPollinator()
        {
            // Arrange
            var mockUpdate = new Mock<IPollinatorRepository>();
            var pollinatorId = "poll001";

            var putPollinator = new Pollinator
            { 
                Id = pollinatorId,
                Name = "Updated Honey Bee",
                UserProfileUid = "user001",
                Description = "Test Description"
            };

            mockUpdate.Setup(repo => repo.UpdatePollinatorAsync(pollinatorId, putPollinator))
                .ReturnsAsync(putPollinator);

            var repo = mockUpdate.Object;

            // Act
            var result = await repo.UpdatePollinatorAsync(pollinatorId, putPollinator);
            
            // Assert
            Assert.NotNull(result);
            Assert.Equal("Updated Honey Bee", result.Name);
            Assert.Equal("user001", result.UserProfileUid);
        }

        [Fact]
        public async Task DeletePollinatorAsync_ReturnsDeletedPollinator()
        {
            // Arrange  
            var mockDelete = new Mock<IPollinatorRepository>();
            var pollinatorId = "poll001";
            var deletedPollinator = new Pollinator
            {
                Id = pollinatorId,
                Name = "Deleted Pollinator",
                UserProfileUid = "user001",
                Description = "Test Description"
            };
            mockDelete.Setup(r => r.DeletePollinatorAsync(pollinatorId))
                .ReturnsAsync(deletedPollinator);
            var service = new PollinatorServices(mockDelete.Object);
            // Act  
            var result = await service.DeletePollinatorAsync(pollinatorId);
            // Assert  
            Assert.NotNull(result);
            Assert.Equal("Deleted Pollinator", result.Name);
        }
    }
}
