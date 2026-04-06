using UniBet.Contexts.Betting.Domain.Entities;

namespace UniBet.Contexts.Betting.Domain.IRepositories;

public interface IGameRepository
{
    public Game FindById(Guid id);
    public void Save(Game game);
    public void Update(Game game);
}