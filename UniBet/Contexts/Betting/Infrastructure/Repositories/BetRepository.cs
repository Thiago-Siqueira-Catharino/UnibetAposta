using UniBet.Contexts.Betting.Domain.Entities;
using UniBet.Contexts.Betting.Domain.IRepositories;
using UniBet.Contexts.Betting.Infrastructure.Persistance;

namespace UniBet.Contexts.Betting.Infrastructure.Repositories;

public class BetRepository : IBetRepository
{
    private readonly BettingDbContext _database;

    public BetRepository()
    {
    }
    
    public BetRepository(BettingDbContext database)
    {
        _database = database;
    }

    public Bet findById(Guid id)
    {
        return _database.Bets
            .Select(bet => bet)
            .Where(bet => bet.Id == id)
            .FirstOrDefault();
    }

    public void Save(Bet bet)
    {
        var entity = findById(bet.Id);
        if (entity == null)
        {
            _database.Bets.Add(bet);
            _database.SaveChanges();
            
            return;
        }
        else
        {
            _database.Bets.Update(bet);
            _database.SaveChanges();
            
            return;
        }
    }

    public void Close(Bet bet)
    {
        Bet betEntity = findById(bet.Id);
        if  (betEntity == null)
                throw new ArgumentException("Bet not found");
        
        betEntity.Close();
        _database.Bets.Update(betEntity);
        _database.SaveChanges();
        
        return;
    }
}