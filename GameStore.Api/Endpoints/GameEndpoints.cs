using GameStore.Api.models;
using GameStore.Api.Repos;

namespace GameStore.Api.Endpoints;

public static class GameEndpoints
{
    const string GetGamesEndpointName = "GetGame";

    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/games").WithParameterValidation();

        group.MapGet("/", (IGamesRepo repo) => repo.GetAll());

        group.MapGet("/{id}", (IGamesRepo repo, int id) =>
        {
            Game? game = repo.GetGame(id) ;
            return game is not null ? Results.Ok(game) : Results.NotFound() ;
        }).WithName(GetGamesEndpointName);

        group.MapPost("/", (IGamesRepo repo, Game game) =>
        {
            repo.Create(game);
            return Results.CreatedAtRoute(GetGamesEndpointName, new { id = game.Id }, game);
        });

        group.MapPut("/{id}", (IGamesRepo repo, int id, Game updatedGame) =>
        {
            Game? existingGame = repo.GetGame(id) ;
            if (existingGame == null) return Results.NotFound();

            existingGame.Id = updatedGame.Id;
            existingGame.Name = updatedGame.Name;
            existingGame.Price = updatedGame.Price;
            existingGame.ReleaseDate = updatedGame.ReleaseDate;
            existingGame.ImageUri = updatedGame.ImageUri;
            repo.Create(existingGame);

            return Results.NoContent();
        });

        group.MapDelete("/{id}", (IGamesRepo repo, int id) =>
        {
            Game? game = repo.GetGame(id);

            if (game is not null) repo.Delete(id);

            return Results.NoContent();
        });

        return group;
    }
}
