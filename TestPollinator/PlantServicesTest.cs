using Xunit;
using Moq;
using PollinatorBE.Interfaces;
using PollinatorBE.Models;
using PollinatorBE.Services;

namespace PollinatorBE.TestPollinator    
{
    public class PlantServicesTest
    {
        [Fact]
        public async Task GetAllPlantsAsync_ReturnsPlants()
        {
            // Arrange
            var mockRepo = new Mock<IPlantRepository>();
            var expectedPlants = new List<Plant>
            {
                new Plant { Id = "1", Name = "Rose", Type = "Flower", Description = "Test Description", Sun = "Full Sun" },
                new Plant { Id = "2", Name = "Tulip", Type = "Flower", Description = "Test Description", Sun = "Full Sun" }
            };
            mockRepo.Setup(repo => repo.GetAllPlantsAsync()).ReturnsAsync(expectedPlants);
            var service = new PlantServices(mockRepo.Object);
            
            // Act
            var result = await service.GetAllPlantsAsync();
            
            // Assert
            Assert.Equal("1", result[0].Id);
            Assert.Equal("Rose", result[0].Name);
        }

        [Fact]
        public async Task GetPlantsByUserUidAsync_ReturnsPlants()
        { 
            // Arrange
            var mockRepo = new Mock<IPlantRepository>();
            var expectedPlants = new List<Plant>
            {
                new Plant { Id = "1", Name = "Daisy", Type = "Flower", Description = "Test Description", Sun = "Full Sun" },
                new Plant { Id = "2", Name = "Tulip", Type = "Flower", Description = "Test Description", Sun = "Full Sun" }
            };
            mockRepo.Setup(repo => repo.GetPlantsByUserUidAsync("user201"))
                .ReturnsAsync(expectedPlants);
            var service = new PlantServices(mockRepo.Object);

            // Act
            var result = await service.GetPlantsByUserUidAsync("user201");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Daisy", result[0].Name);
        }

        [Fact]
        public async Task GetPlantByIdAsync_ReturnsPlant()
        {
            // Arrange
            var mockRepo = new Mock<IPlantRepository>();
            var expectedPlant = new Plant
            {
                Id = "1",
                Name = "Gardenia",
                Type = "Bush",
                Description = "Test Description",
                Sun = "Partial Sun"
            };
            mockRepo.Setup(repo => repo.GetPlantByIdAsync("1")).ReturnsAsync(expectedPlant);

            var service = new PlantServices(mockRepo.Object);

            // Act
            var result = await service.GetPlantByIdAsync("1");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Gardenia", result.Name);
        }

        [Fact]
        public async Task CreatePlantAsync_ReturnsCreatedPlant()
        {
            // Arrange  
            var mockPlant = new Plant
            {
                Id = "plant205",
                Name = "Honeysuckle",
                Type = "Bush",
                Description = "Test Description",
                Sun = "Partial Sun"
            };

            var mockRepo = new Mock<IPlantRepository>();
            mockRepo.Setup(repo => repo.CreatePlantAsync(It.IsAny<Plant>()))
                    .ReturnsAsync((Plant p) => p);

            var repo = mockRepo.Object;

            // Act
            var result = await repo.CreatePlantAsync(mockPlant);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Honeysuckle", result.Name);
            Assert.Equal("Partial Sun", result.Sun);
        }

        [Fact]
        public async Task UpdatePlantAsync_ReturnUpdatedPlant()
        {
            // Arrange
            var mockUpdate = new Mock<IPlantRepository>();
            var PlantId = "plant205";

            var putPlant = new Plant
            {
                Id = "plant205",
                Name = "Amaryllis",
                Type = "Flower",
                Description = "Test Description",
                Sun = "Full Sun"
            };

            mockUpdate.Setup(repo => repo.UpdatePlantAsync(PlantId, putPlant))
                .ReturnsAsync(putPlant);

            var repo = mockUpdate.Object;

            // Act
            var result = await repo.UpdatePlantAsync(PlantId, putPlant);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Amaryllis", result.Name);
            Assert.Equal("Full Sun", result.Sun);
        }

        [Fact]
        public async Task DeletePlantAsync_ReturnsDeletedPlant()
        {
            // Arrange  
            var mockDelete = new Mock<IPlantRepository>();
            var PlantId = "poll001";
            var deletedPlant = new Plant
            {
                Id = "1",
                Name = "Gardenia",
                Type = "Bush",
                Description = "Test Description",
                Sun = "Partial Sun"
            };
            mockDelete.Setup(r => r.DeletePlantAsync(PlantId))
                .ReturnsAsync(deletedPlant);
            var service = new PlantServices(mockDelete.Object);
            
            // Act  
            var result = await service.DeletePlantAsync(PlantId);
            
            // Assert  
            Assert.NotNull(result);
            Assert.Equal("Deleted Plant", result.Name);
        }
    }
}
