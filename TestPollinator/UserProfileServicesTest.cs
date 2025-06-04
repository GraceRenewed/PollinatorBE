using Xunit;
using Moq;
using PollinatorBE.Interfaces;
using PollinatorBE.Models;
using PollinatorBE.Services;

namespace PollinatorBE.TestPollinator
{
    public class UserProfileServicesTest
    {
        [Fact]
        public async Task GetUserProfilesAsync_ReturnsUserProfiles()
        {
            // Arrange  
            var mockRepo = new Mock<IUserProfileRepository>();
            var expectedUsers = new List<UserProfile>
            {
                new UserProfile { Uid = "1", UserName = "FlowerGirl", Email = "fg@email.com" },
                new UserProfile { Uid = "2", UserName = "ButterCup", Email = "ButterCup@email.com" }
            };
            mockRepo.Setup(repo => repo.GetUserProfilesAsync()).ReturnsAsync(expectedUsers);

            var service = new UserProfileServices(mockRepo.Object);

            // Act
            var result = await service.GetUserProfilesAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("ButterCup", result[1].UserName);
        }

        [Fact]
        public async Task GetUserByUidAsync_ReturnsUser()
        {
            // Arrange
            var mockRepo = new Mock<IUserProfileRepository>();
            var expectedUser = new UserProfile
            {
                Uid = "user200",
                UserName = "RedThroated",
                Email = "red@email.com"
            };
            mockRepo.Setup(repo => repo.GetUserByUidAsync("1")).ReturnsAsync(expectedUser);

            var service = new UserProfileServices(mockRepo.Object);

            // Act
            var result = await service.GetUserByUidAsync("1");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("RedThroated", result.UserName);
        }

        [Fact]
        public async Task CreateUserProfileAsync_ReturnsCreatedUserProfile()
        {
            // Arrange
            var mockUserProfile = new UserProfile
            {
                Uid = "user205",
                UserName = "Moth",
                Email = "moth@email.com"
            };

            var mockRepo = new Mock<IUserProfileRepository>();
            mockRepo.Setup(repo => repo.CreateUserProfileAsync(It.IsAny<UserProfile>()))
                    .ReturnsAsync((UserProfile p) => p);

            var repo = mockRepo.Object;

            // Act
            var result = await repo.CreateUserProfileAsync(mockUserProfile);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Moth", result.UserName);
            Assert.Equal("user205", result.Uid);
        }

        [Fact]
        public async Task UpdateUserAsync_ReturnUpdatedUser()
        {
            // Arrange
            var mockUpdate = new Mock<IUserProfileRepository>();
            var UserUid = "user205";

            var putUserProfile = new UserProfile
            {
                Uid = "user205",
                UserName = "Updated Moth",
                Email = "moth2@email.com"
            };

            mockUpdate.Setup(repo => repo.UpdateUserAsync(UserUid, putUserProfile))
                .ReturnsAsync(putUserProfile);

            var repo = mockUpdate.Object;

            // Act
            var result = await repo.UpdateUserAsync(UserUid, putUserProfile);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Updated Moth", result.UserName);
            Assert.Equal("moth2@email.com", result.Email);
        }

        [Fact]
        public async Task DeleteUserAsync_ReturnsDeletedUser()
        {
            // Arrange  
            var mockDelete = new Mock<IUserProfileRepository>();
            var UserId = "poll001";
            var deletedUser = new UserProfile
            {
                Uid = "user205",
                UserName = "Deleted User",
                Email = "moth2@email.com"
            };
            mockDelete.Setup(r => r.DeleteUserAsync(UserId))
                .ReturnsAsync(deletedUser);
            var service = new UserProfileServices(mockDelete.Object);
            // Act  
            var result = await service.DeleteUserAsync(UserId);
            // Assert  
            Assert.NotNull(result);
            Assert.Equal("Deleted User", result.UserName);
        }
    }
}
