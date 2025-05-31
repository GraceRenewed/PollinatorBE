using Microsoft.AspNetCore.Builder;
using PollinatorBE.Interfaces;
using PollinatorBE.Models;
using PollinatorBE.Services;

namespace PollinatorBE.Endpoints
{
    public static class UserProfileEndpoints
    {
        public static void MapUserProfileEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/UserProfile").WithTags(nameof(UserProfile));

            // Get all User Profiles
            group.MapGet("/", async (IUserProfileServices userProfileServices) =>
            {
                return await userProfileServices.GetUserProfilesAsync();
            })
                .WithName("GetUserProfiles")
                .WithOpenApi()
                .Produces<List<UserProfile>>(StatusCodes.Status200OK);

            // Get User by User Uid
            group.MapGet("/{uid}", async (string uid, IUserProfileServices userProfileServices) =>
                {
                var result = await userProfileServices.GetUserByUidAsync(uid);
                return result is not null ? Results.Ok(result) : Results.NotFound();
                })
                .WithName("GetUsersByUid")
                .WithOpenApi()
                .Produces(StatusCodes.Status404NotFound);

            // Create User Profile
            group.MapPost("/", async (UserProfile userProfile, IUserProfileServices userProfileServices) =>
            {
                var createUser = await userProfileServices.CreateUserProfileAsync(userProfile);
                return createUser is not null ? Results.Created($"/userProfiles/{createUser.Uid}", createUser) : Results.BadRequest();
            })
                .WithName("CreateUserProfile")
                .WithOpenApi()
                .Produces<UserProfile>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest);

            // Update User Profile
            group.MapPut("/{uid}", async (string uid, UserProfile userProfile, IUserProfileServices userProfileServices) =>
            {
                var updatedUser = await userProfileServices.UpdateUserAsync(uid, userProfile);
                return updatedUser is not null ? Results.Ok(updatedUser) : Results.NotFound();
            })
                .WithName("UpdateUser")
                .WithOpenApi()
                .Produces<UserProfile>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);

            group.MapDelete("/{uid}", async (string uid, IUserProfileServices userProfileServices) =>
            {
                var deleteUser = await userProfileServices.DeleteUserAsync(uid);
                return deleteUser is not null ? Results.Ok(deleteUser) : Results.NotFound();
            })
                .WithName("DeleteUser")
                .WithOpenApi()
                .Produces<UserProfile>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);
        }
    }
}
