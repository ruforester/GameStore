using GameStore.Api.Entities;
using GameStore.Api.Repositories;

namespace GameStore.Api.Endpoints;

public static class GamesEnpoints
{
    const string GetGameEnpointName = "GetGame";
    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/games").WithParameterValidation();
        InMemGamesRepository repository = new();

        group.MapGet("/", () => repository.GetAll());

        group.MapGet("/{id}", (int id) =>
        {
            Game? game = repository.Get(id);
            return game is not null ? Results.Ok(game) : Results.NotFound();
        })
        .WithName(GetGameEnpointName);

        group.MapPost("/", (Game game) =>
        {
            repository.Create(game);
            return Results.CreatedAtRoute(GetGameEnpointName, new { id = game.Id }, game);
        });

        group.MapPut("/{id}", (int id, Game updatedGame) =>
        {
            Game? existingGame = repository.Get(id);
            if (existingGame is null)
            {
                return Results.NotFound();
            }
            existingGame.Name = updatedGame.Name;
            existingGame.Genre = updatedGame.Genre;
            existingGame.ReleaseDate = updatedGame.ReleaseDate;
            existingGame.ImageUri = updatedGame.ImageUri;
            existingGame.Price = updatedGame.Price;
            repository.Update(existingGame);
            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id) =>
        {
            Game? game = repository.Get(id);
            if (game is not null)
            {
                repository.Delete(id);
            }
            return Results.NoContent();
        });

        return group;
    }
}