using Xunit;
using Moq;
using PollinatorBE.Interfaces;
using PollinatorBE.Models;
using PollinatorBE.Services;
using Microsoft.EntityFrameworkCore;

namespace PollinatorBE.TestPollinator
{
    public class GardenPlantServicesTest
    {
        [Fact]
        public async Task GetGardenPlantsAsync_ReturnsGardenPlants()
        {
            // Arrange
            var mockRepo = new Mock<IGardenPlantRepository>();
            var expectedGardenPlants = new List<GardenPlant>
            {
                new GardenPlant { Id = "gp200", GardenId = "garden220", PlantId = "plant220" },
                new GardenPlant { Id = "gp201", GardenId = "garden225", PlantId = "plant225" }
            };
            mockRepo.Setup(repo => repo.GetGardenPlantsAsync()).ReturnsAsync(expectedGardenPlants);

            var service = new GardenPlantServices(mockRepo.Object);

            // Act
            var result = await service.GetGardenPlantsAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("gp200", result[0].Id);
        }

        [Fact]
        public async Task GetGardenPlantsByIdAsync_ReturnsGardenPlant()
        {
            // Arrange
            var mockRepo = new Mock<IGardenPlantRepository>();
            var expectedGardenPlants = new List<GardenPlant>
            {
                new GardenPlant { Id = "gp200", GardenId = "garden220", PlantId = "plant220" },
                new GardenPlant { Id = "gp201", GardenId = "garden225", PlantId = "plant225" }
            };
            
            mockRepo.Setup(repo => repo.GetGardenPlantsByIdAsync("gp200")).ReturnsAsync(expectedGardenPlants);

            var service = new GardenPlantServices(mockRepo.Object);

            // Act
            var result = await service.GetGardenPlantsByIdAsync("gp200");

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("gp200", result[0].Id);
        }
        
        [Fact]
        public async Task CreateGardenPlantsAsync_ReturnsCreatedGardenPlant()
        {
            // Arrange
            var mockRepo = new Mock<IGardenPlantRepository>();
            var newGardenPlant = new GardenPlant
            {
                Id = "gp12",
                GardenId = "garden003",
                PlantId = "plant_flp003"
            };
            mockRepo.Setup(repo => repo.CreateGardenPlantsAsync(It.IsAny<GardenPlant>()))
                    .ReturnsAsync(newGardenPlant);
            var service = new GardenPlantServices(mockRepo.Object);
            // Act
            var result = await service.CreateGardenPlantsAsync(newGardenPlant);
            // Assert
            Assert.NotNull(result);
            Assert.Equal("gp12", result.Id);
        }

        [Fact]
        public async Task UpdateGardenPlantAsync_ReturnUpdatedGardenPlant()
        {
            // Arrange
            var mockUpdate = new Mock<IGardenPlantRepository>();
            var GardenPlantId = "gp12";

            var putGardenPlant = new GardenPlant
            {
                Id = "gp12",
                GardenId = "garden004",
                PlantId = "plant_flp002",
            };

            mockUpdate.Setup(repo => repo.UpdateGardenPlantAsync(GardenPlantId, putGardenPlant))
                .ReturnsAsync(putGardenPlant);

            var repo = mockUpdate.Object;

            // Act
            var result = await repo.UpdateGardenPlantAsync(GardenPlantId, putGardenPlant);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("garden004", result.GardenId);
            Assert.Equal("plant_flp002", result.PlantId);
        }

        [Fact]
        public async Task DeleteGardenPlantAsync_ReturnsDeletedPlant()
        {
            // Arrange  
            var mockDelete = new Mock<IGardenPlantRepository>();
            var GardenPlantId = "gp12";
            var deletedGardenPlant = new GardenPlant
            {
                Id = "gp12",
                GardenId = "garden004",
                PlantId = "plant_flp002",
            };

            mockDelete.Setup(r => r.DeleteGardenPlantAsync(GardenPlantId))
                .ReturnsAsync(deletedGardenPlant);
            var service = new GardenPlantServices(mockDelete.Object);

            // Act  
            var result = await service.DeleteGardenPlantAsync(GardenPlantId);

            // Assert  
            Assert.NotNull(result);
            Assert.Equal("gp12", result.Id);
        }
    }
}
