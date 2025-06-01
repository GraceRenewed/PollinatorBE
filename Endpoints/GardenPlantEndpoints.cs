using PollinatorBE.Interfaces;
using PollinatorBE.Models;

namespace PollinatorBE.Endpoints
{
    public static class GardenPlantEndpoints
    {
        public static void MapGardenPlantEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/GardenPlant").WithTags(nameof(GardenPlant));
            
            // Get GardenPlants
            group.MapGet("/", async (IGardenPlantServices gardenPlantServices) =>
            {
                return await gardenPlantServices.GetGardenPlantsAsync();
            })
                .WithName("GetAllGardenPlants")
                .WithOpenApi()
                .Produces<List<GardenPlant>>(StatusCodes.Status200OK);
            
            // Get GardenPlants by Id
            group.MapGet("/GetGardenPlantsById/{id}", async (IGardenPlantServices gardenPlantServices, string id) =>
            {
                var gardenPlants = await gardenPlantServices.GetGardenPlantsByIdAsync(id);
                return Results.Ok(gardenPlants);
            })
                .WithName("GetGardenPlantsById")
                .WithOpenApi()
                .Produces<GardenPlant>(StatusCodes.Status200OK);

            // Create GardenPlant
            group.MapPost("/", async (IGardenPlantServices gardenPlantServices, GardenPlant gardenPlant) =>
            {
                var createGardenPlant = await gardenPlantServices.CreateGardenPlantsAsync(gardenPlant);
                return Results.Created($"/api/GardenPlant/{createGardenPlant.Id}", createGardenPlant);
            })
                .WithName("CreateGardenPlant")
                .WithOpenApi()
                .Produces<GardenPlant>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest);

            // Update GardenPlant
            group.MapPut("/{id}", async (IGardenPlantServices gardenPlantServices, string id, GardenPlant gardenPlant) =>
            {
                var updatedGardenPlant = await gardenPlantServices.UpdateGardenPlantAsync(id, gardenPlant);
                return Results.Ok(updatedGardenPlant);
            })
                .WithName("UpdateGardenPlant")
                .WithOpenApi()
                .Produces<GardenPlant>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status204NoContent);

            // Delete GardenPlant
            group.MapDelete("/{id}", async (IGardenPlantServices gardenPlantServices, string id) =>
            {
                var deletedGardenPlant = await gardenPlantServices.DeleteGardenPlantAsync(id);
                return Results.NoContent();
            })
                .WithName("DeleteGardenPlant")
                .WithOpenApi()
                .Produces<GardenPlant>(StatusCodes.Status204NoContent);
        }
    }
}
            