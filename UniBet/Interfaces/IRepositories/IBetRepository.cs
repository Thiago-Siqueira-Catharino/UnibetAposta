using UniBet.Entities;

namespace UniBet.Interfaces.IRepositories;

public interface IBetRepository
{
    public Bet findById(Guid id);
    public void Save(Bet bet);
    public void Close(Bet bet);
}