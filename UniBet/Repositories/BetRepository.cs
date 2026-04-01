using UniBet.Entities;
using UniBet.Interfaces.IRepositories;

namespace UniBet.Repositories;

public interface BetRepository : IBetRepository
{
    public Bet FindById(Guid id);
}