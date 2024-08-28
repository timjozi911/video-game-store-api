using GameStore.Api.models;

namespace GameStore.Api.Repos
{
    public interface IGamesRepo
    {
        void Create(Game game);
        void Delete(int id);
        IEnumerable<Game> GetAll();
        Game? GetGame(int id);
        void Update(Game updatedGame);
    }
}