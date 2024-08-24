using GameStore.Api.models;

const string GetGamesEndpointName = "GetGame";

List<Game> games = new()
{
    new Game()
    {
        Id = 1,
        Name = "SF 2",
        Genre = "fighting",
        Price = 19.99M,
        ImageUri = "https://placehold.co/100",
        ReleaseDate = new DateTime(1991, 2,2),
    },
    new Game()
    {
        Id = 2,
        Name = "FF 12",
        Genre = "role playing",
        Price = 19.99M,
        ImageUri = "https://placehold.co/100",
        ReleaseDate = new DateTime(2010, 9,30),
    },
    new Game()
    {
        Id = 3,
        Name = "Fifa 23",
        Genre = "sport",
        Price = 69.99M,
        ImageUri = "https://placehold.co/100",
        ReleaseDate = new DateTime(2022, 9,27),
    }
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var group = app.MapGroup("/games");

group.MapGet("/", () => games);

group.MapGet("/{id}", (int id) =>
{
    Game? game = games.Find(game => game.Id == id);
    if (game == null) return Results.NotFound();
    return Results.Ok(game);
}).WithName(GetGamesEndpointName);

group.MapPost("/", (Game game) => 
{
    game.Id = games.Max(game => game.Id) + 1;
    games.Add(game);

    return Results.CreatedAtRoute(GetGamesEndpointName, new {id = game.Id}, game);
});

group.MapPut("/{id}", (int id, Game updatedGame) => 
{
    Game? existingGame = games.Find(game => game.Id == id);
    if (existingGame == null) return Results.NotFound();

    existingGame.Id = updatedGame.Id;
    existingGame.Name = updatedGame.Name;
    existingGame.Price = updatedGame.Price;
    existingGame.ReleaseDate = updatedGame.ReleaseDate;
    existingGame.ImageUri = updatedGame.ImageUri;
    games.Add(existingGame);

    return Results.NoContent();
});

group.MapDelete("/{id}", (int id) =>
{
    Game? game = games.Find(game => game.Id == id);

    if (game is not null) games.Remove(game);
    
    return Results.NoContent();
});

app.Run();
