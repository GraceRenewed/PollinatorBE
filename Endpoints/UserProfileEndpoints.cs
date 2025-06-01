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
            group.MapGet("/{uid}", async (IUserProfileServices userProfileServices, string uid) =>
                {
                var result = await userProfileServices.GetUserByUidAsync(uid);
                    return Results.Ok(result);
                })
                .WithName("GetUsersByUid")
                .WithOpenApi()
                .Produces<UserProfile>(StatusCodes.Status200OK);

            // Create User Profile
            group.MapPost("/", async (IUserProfileServices userProfileServices, UserProfile userProfile) =>
            {
                var createUser = await userProfileServices.CreateUserProfileAsync(userProfile);
                return createUser is not null ? Results.Created($"/api/UserProfile/{createUser.Uid}", createUser);
            })
                .WithName("CreateUserProfile")
                .WithOpenApi()
                .Produces<UserProfile>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest);

            // Update User Profile
            group.MapPut("/{uid}", async (IUserProfileServices userProfileServices, string uid, UserProfile userProfile) =>
            {
                var updatedUser = await userProfileServices.UpdateUserAsync(uid, userProfile);
                return Results.Ok(updatedUser);
            })
                .WithName("UpdateUser")
                .WithOpenApi()
                .Produces<UserProfile>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status204NoContent);

            group.MapDelete("/{uid}", async (string uid, IUserProfileServices userProfileServices) =>
            {
                var deleteUser = await userProfileServices.DeleteUserAsync(uid);
                return Results.NoContent();
            })
                .WithName("DeleteUser")
                .WithOpenApi()
                .Produces<UserProfile>(StatusCodes.Status204NoContent);
                
        }
    }
}
