using GameStore.Api.Dtos;

namespace GameStore.Api.models;

public static class ModelExtensions
{
    public static GameDto AsDto(this Game game)
    { 
        return new GameDto(
            game.Id, 
            game.Name,
            game.Genre, 
            game.Price,
            game.ReleaseDate,
            game.ImageUri
        ); 
    }
}
