using GameStore.Api.Endpoints;
using GameStore.Api.Repos;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IGamesRepo, InMemoryRepo>();

var app = builder.Build();
app.MapGamesEndpoints();

app.Run();
