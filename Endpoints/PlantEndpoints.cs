using PollinatorBE.Interfaces;
using PollinatorBE.Models;

namespace PollinatorBE.Endpoints
{
    public static class PlantEndpoints
    {
        public static void MapPlantEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/Plant").WithTags(nameof(Plant));

            // Get all Plants
            group.MapGet("/", async (IPlantServices plantServices) =>
                {
                    return await plantServices.GetAllPlantsAsync();
                })
                    .WithName("GetAllPlants")
                    .WithOpenApi()
                    .Produces<List<Plant>>(StatusCodes.Status200OK);

            // Get Plants by User Uid
            group.MapGet("/user/{userUid}", async (IPlantServices plantServices, string userUid) =>
            {
                var result = await plantServices.GetPlantsByUserUidAsync(userUid);
                return Results.Ok(result);
            })
                .WithName("GetPlantsByUserUid")
                .WithOpenApi()
                .Produces<List<Plant>>(StatusCodes.Status200OK);

            // Get Plants by Pollinator Id
            group.MapGet("/pollinator/{pollinatorId}", async (IPlantServices plantServices, string pollinatorId) =>
            {
                var result = await plantServices.GetPlantsByPollinatorIdAsync(pollinatorId);
                return Results.Ok(result);
            })
                .WithName("GetPlantsByPollinatorId")
                .WithOpenApi()
                .Produces<List<Plant>>(StatusCodes.Status200OK);

            // Get Plant by Id
            group.MapGet("/{id}", async (IPlantServices plantServices, string id) =>
            {
                var result = await plantServices.GetPlantByIdAsync(id);
                return Results.Ok(result);
            })
                .WithName("GetPlantById")
                .WithOpenApi()
                .Produces<Plant>(StatusCodes.Status200OK);

            // Create Plant
            group.MapPost("/", async (IPlantServices plantServices, Plant plant) =>
            {
                var createdPlant = await plantServices.CreatePlantAsync(plant);
                return Results.Created($"/api/Plant/{createdPlant.Id}", createdPlant);
            })
                .WithName("CreatePlant")
                .WithOpenApi()
                .Produces<Plant>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest);

            // Update Plant
            group.MapPut("/{id}", async (IPlantServices plantServices, string id, Plant plant) =>
            {
                var updatedPlant = await plantServices.UpdatePlantAsync(id, plant);
                return Results.Ok(updatedPlant);
            })
                .WithName("UpdatePlant")
                .WithOpenApi()
                .Produces<Plant>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status204NoContent);

            // Delete Plant
            group.MapDelete("/{id}", async (IPlantServices plantServices, string id) =>
            {
                var deletedPlant = await plantServices.DeletePlantAsync(id);
                return Results.NoContent();
            })
                .WithName("DeletePlant")
                .WithOpenApi()
                .Produces<Plant>(StatusCodes.Status204NoContent);
        }
    }
}
