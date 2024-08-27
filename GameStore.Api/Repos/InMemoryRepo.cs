using GameStore.Api.models;

namespace GameStore.Api.Repos;

public class InMemoryRepo
{
    readonly private List<Game> games = new()
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

    public IEnumerable<Game> GetAll()
    {
        return games;
    }

    public Game? GetGame(int id) 
    {
        return games.Find(game => game.Id == id);
    }

    public void Create(Game game)
    {
        game.Id = games.Max(game => game.Id) + 1;
        games.Add(game);
    }

    public void Update(Game updatedGame)
    {
        var index = games.FindIndex(game  => game.Id == updatedGame.Id);
        games[index] = updatedGame;
    }

    public void Delete(int id)
    {
        var index = games.FindIndex(game => game.Id == id);
        games.RemoveAt(index);
    }
}
