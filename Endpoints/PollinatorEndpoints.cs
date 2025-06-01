using PollinatorBE.Interfaces;
using PollinatorBE.Models;
using PollinatorBE.Services;

namespace PollinatorBE.Endpoints
{
    public static class PollinatorEndpoints
    {
        public static void MapPollinatorEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/Pollinator").WithTags(nameof(Pollinator));

            // Get all Pollinators
            group.MapGet("/", async (IPollinatorServices pollinatorServices) =>
            {
                return await pollinatorServices.GetAllPollinatorsAsync();
            })
                .WithName("GetAllPollinators")
                .WithOpenApi()
                .Produces<List<Pollinator>>(StatusCodes.Status200OK);

            // Get Pollinators by Plant Id
            group.MapGet("/plant/{plantId}", async (IPollinatorServices pollinatorServices, string plantId) =>
            {
                var result = await pollinatorServices.GetPollinatorsByPlantIdAsync(plantId);
                return Results.Ok(result);
            })
                .WithName("GetPollinatorsByPlantId")
                .WithOpenApi()
                .Produces<List<Pollinator>>(StatusCodes.Status200OK);

            // Get Pollinators by Garden Id
            group.MapGet("/garden/{gardenId}", async (IPollinatorServices pollinatorServices, string gardenId) =>
            {
                var result = await pollinatorServices.GetPollinatorsByGardenIdAsync(gardenId);
                return Results.Ok(result);
            })
                .WithName("GetPollinatorsByGardenId")
                .WithOpenApi()
                .Produces<List<Pollinator>>(StatusCodes.Status200OK);

            // Get Pollinator by Id
            group.MapGet("/{id}", async (IPollinatorServices pollinatorServices, string id) =>
            {
                var result = await pollinatorServices.GetPollinatorByIdAsync(id);
                return Results.Ok(result);
            })
                .WithName("GetPollinatorById")
                .WithOpenApi()
                .Produces<Pollinator>(StatusCodes.Status200OK);

            // Create Pollinator
            group.MapPost("/", async (IPollinatorServices pollinatorServices, Pollinator pollinator) =>
            {
                var createdPollinator = await pollinatorServices.CreatePollinatorAsync(pollinator);
                return Results.Created($"/api/Pollinator/{createdPollinator.Id}", createdPollinator);
            })
                .WithName("CreatePollinator")
                .WithOpenApi()
                .Produces<Pollinator>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest);

            // Update Pollinator
            group.MapPut("/{id}", async (IPollinatorServices pollinatorServices, string id, Pollinator pollinator) =>
            {
                var updatedPollinator = await pollinatorServices.UpdatePollinatorAsync(id, pollinator);
                return Results.Ok(updatedPollinator);
            })
                .WithName("UpdatePollinator")
                .WithOpenApi()
                .Produces<Pollinator>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status204NoContent);

            // Delete Pollinator
            group.MapDelete("/{id}", async (IPollinatorServices pollinatorServices, string id) =>
            {
                var deletedPollinator = await pollinatorServices.DeletePollinatorAsync(id);
                return Results.NoContent();
            })
                .WithName("DeletePollinator")
                .WithOpenApi()
                .Produces<Pollinator>(StatusCodes.Status204NoContent);
            }
        }
    }
