using PollinatorBE.Interfaces;
using PollinatorBE.Models;

namespace PollinatorBE.Endpoints
{
    public static class GardenEndpoints
    {
        public static void MapGardenEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/Garden").WithTags(nameof(Garden));

            // Get all Gardens
            group.MapGet("/", async (IGardenServices gardenServices) =>
            {
                return await gardenServices.GetAllGardensAsync();
            })
            .WithName("GetAllGardens")
            .WithOpenApi()
            .Produces<List<Garden>>(StatusCodes.Status200OK);

            // Get Garden by Id
            group.MapGet("/{id}", async (IGardenServices gardenServices, string id) =>
            {
                var garden = await gardenServices.GetGardenByIdAsync(id);
                return Results.Ok(garden);
            })
                .WithName("GetGardenById")
                .WithOpenApi()
                .Produces<Garden>(StatusCodes.Status200OK);

            // Get Gardens by User Uid
            group.MapGet("/UserUid/{userUid}", async (IGardenServices gardenServices, string userUid) =>
            {
                var userGardens = await gardenServices.GetGardensByUserIdAsync(userUid);
                return Results.Ok(userGardens);
            })
                .WithName("GetGardensByUserUid")
                .WithOpenApi()
                .Produces<Garden>(StatusCodes.Status200OK);

            // Create Garden
            group.MapPost("/", async (IGardenServices gardenServices, Garden garden) =>
            {
                var createGarden = await gardenServices.CreateGardenAsync(garden);
                return Results.Created($"/api/Garden/{createGarden.Id}", createGarden);
            })
                .WithName("CreateGarden")
                .WithOpenApi()
                .Produces<Garden>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest);

            // Update Garden
            group.MapPut("/{id}", async (IGardenServices gardenServices, string id, Garden garden) =>
            {
                var updatedGarden = await gardenServices.UpdateGardenAsync(id, garden);
                return Results.Ok(updatedGarden);
            })
                .WithName("UpdateGarden")
                .WithOpenApi()
                .Produces<Garden>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status204NoContent);

            // Delete Garden
            group.MapDelete("/{id}", async (IGardenServices gardenServices, string id) =>
            {
                var deletedGarden = await gardenServices.DeleteGardenAsync(id);
                return Results.NoContent();
            })
                .WithName("DeleteGarden")
                .WithOpenApi()
                .Produces<Garden>(StatusCodes.Status204NoContent);
        }
    }
}
