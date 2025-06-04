using Xunit;
using Moq;
using PollinatorBE.Interfaces;
using PollinatorBE.Models;
using PollinatorBE.Services;

namespace PollinatorBE.TestPollinator
{
    public class GardenServicesTest
    {
        [Fact]
        public async Task GetAllGardensAsync_ReturnsGardens()
        {
            // Arrange
            var mockRepo = new Mock<IGardenRepository>();
            var expectedGardens = new List<Garden>
            {
                new Garden { Id = "1", Type = "Flower" },
                new Garden { Id = "2", Type = "Flower Pot" }
            };
            mockRepo.Setup(repo => repo.GetAllGardensAsync()).ReturnsAsync(expectedGardens);

            var service = new GardenServices(mockRepo.Object);

            // Act
            var result = await service.GetAllGardensAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Flower", result[0].Type);
        }

        [Fact]
        public async Task GetGardenByIdAsync_ReturnsGarden()
        {
            // Arrange
            var mockRepo = new Mock<IGardenRepository>();
            var expectedGarden = new Garden
            {
                Id = "garden201",
                Type = "Raised",
            };
            mockRepo.Setup(repo => repo.GetGardenByIdAsync("1")).ReturnsAsync(expectedGarden);

            var service = new GardenServices(mockRepo.Object);

            // Act
            var result = await service.GetGardenByIdAsync("1");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Raised", result.Type);
        }

        [Fact]
        public async Task GetGardensByUserUidAsync_ReturnsPlants()
        {
            // Arrange
            var mockRepo = new Mock<IGardenRepository>();
            var expectedGardens = new List<Garden>
            {
                new Garden { Id = "1", Type = "Pot" },
                new Garden { Id = "2", Type = "Flower" }
            };
            mockRepo.Setup(repo => repo.GetGardensByUserIdAsync("user201"))
                .ReturnsAsync(expectedGardens);
            var service = new GardenServices(mockRepo.Object);

            // Act
            var result = await service.GetGardensByUserIdAsync("user201");

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Pot", result[0].Type);
        }

        [Fact]
        public async Task CreateGardenAsync_ReturnsCreatedGarden()
        {
            // Arrange
            var mockGarden = new Garden
            {
                Id = "garden205",
                Type = "Vegetable"
            };

            var mockRepo = new Mock<IGardenRepository>();
            mockRepo.Setup(repo => repo.CreateGardenAsync(It.IsAny<Garden>()))
                    .ReturnsAsync((Garden p) => p);

            var repo = mockRepo.Object;

            // Act
            var result = await repo.CreateGardenAsync(mockGarden);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("garden205", result.Id);
            Assert.Equal("Vegetable", result.Type);
        }

        [Fact]
        public async Task UpdateGardenAsync_ReturnUpdatedGarden()
        {
            // Arrange
            var mockUpdate = new Mock<IGardenRepository>();
            var GardenId = "garden205";

            var putGarden = new Garden
            {
                Id = "garden205",
                Type = "Fruit"
            };

            mockUpdate.Setup(repo => repo.UpdateGardenAsync(GardenId, putGarden))
                .ReturnsAsync(putGarden);

            var repo = mockUpdate.Object;

            // Act
            var result = await repo.UpdateGardenAsync(GardenId, putGarden);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("garden205", result.Id);
            Assert.Equal("Fruit", result.Type);
        }

        [Fact]
        public async Task DeleteGardenAsync_ReturnsDeletedGarden()
        {
            // Arrange  
            var mockDelete = new Mock<IGardenRepository>();
            var GardenId = "garden205";
            var deletedGarden = new Garden
            {
                Id = "garden205",
                Type = "Fruit"
            };
            mockDelete.Setup(r => r.DeleteGardenAsync(GardenId))
                .ReturnsAsync(deletedGarden);
            var service = new GardenServices(mockDelete.Object);
            // Act  
            var result = await service.DeleteGardenAsync(GardenId);
            // Assert  
            Assert.NotNull(result);
            Assert.Equal("Fruit", result.Type);
        }
    }
}
