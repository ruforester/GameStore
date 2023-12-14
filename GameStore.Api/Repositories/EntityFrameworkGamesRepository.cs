using GameStore.Api.Data;
using GameStore.Api.Entities;

namespace GameStore.Api.Repositories;

public class EntityFrameworkGamesRepository : IGamesRepository
{
    private readonly GameStoreContext dbContext;

    public EntityFrameworkGamesRepository(GameStoreContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void Create(Game game)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Game? Get(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Game> GetAll()
    {
        return dbContext.Games
    }

    public void Update(Game updatedGame)
    {
        throw new NotImplementedException();
    }
}