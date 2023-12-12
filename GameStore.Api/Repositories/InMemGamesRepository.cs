using GameStore.Api.Entities;

namespace GameStore.Api.Repositories;

public class InMemGamesRepository : IGamesRepository
{
    private List<Game> games = new()
    {
        new Game()
        {
            Id = 1,
            Name = "Game 1",
            Genre = "Genre 1",
            ReleaseDate = new DateOnly(1991, 9, 2),
            ImageUri = "https://placehold.co/100",
            Price = 19.99M
        },
        new Game()
        {
            Id = 2,
            Name = "Game 2",
            Genre = "Genre 2",
            ReleaseDate = new DateOnly(2022, 12, 17),
            ImageUri = "https://placehold.co/100",
            Price = 69.99M
        },
        new Game()
        {
            Id = 3,
            Name = "Game 3",
            Genre = "Genre 3",
            ReleaseDate = new DateOnly(2002, 9, 22),
            ImageUri = "https://placehold.co/100",
            Price = 39.99M
        },
    };
    public IEnumerable<Game> GetAll()
    {
        return games;
    }
    public Game? Get(int id)
    {
        Game? game = games.Find(g => g.Id == id);
        return game;
    }
    public void Create(Game game)
    {
        games.Add(game);
    }
    public void Update(Game updatedGame)
    {
        int index = games.FindIndex(g => g.Id == updatedGame.Id);
        games[index] = updatedGame;
    }
    public void Delete(int id)
    {
        int index = games.FindIndex(g => g.Id == id);
        games.RemoveAt(index);
    }
}