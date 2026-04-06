using UniBet.Contexts.Betting.Domain.Entities;

namespace UniBet.Contexts.Betting.Domain.IRepositories;

public interface IPlayerRepository
{
    public Player FindById(Guid userId);
    public Player Update(Player player);
}