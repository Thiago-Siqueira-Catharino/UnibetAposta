using UniBet.Contexts.Betting.Domain.Entities;

namespace UniBet.Contexts.Betting.Domain.IRepositories;

public interface IBetRepository
{
    public Bet findById(Guid id);
    public void Save(Bet bet);
    public void Close(Bet bet);
}