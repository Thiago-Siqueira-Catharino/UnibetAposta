using Microsoft.EntityFrameworkCore;
using UniBet.Contexts.Betting.Domain.Entities;
using UniBet.Contexts.Betting.Domain.IRepositories;
using UniBet.Contexts.Betting.Infrastructure.Persistance;

namespace UniBet.Contexts.Betting.Infrastructure.Repositories;

public class GameRepository : IGameRepository
{
    private readonly BettingDbContext _betRepository;

    public GameRepository()
    {
    }

    public GameRepository(BettingDbContext betRepository)
    {
        _betRepository = betRepository;
    }
    
    public Game FindById(Guid gameId)
    {
        Console.WriteLine("O ID AQUI!" + gameId);
        Game game = _betRepository.Games
            .FirstOrDefault(game => game.Id == gameId);
            
        return game;
    }

    public void Update(Game game)
    {   
        _betRepository.Games.Update(game);
        _betRepository.SaveChanges();
    }
    
    public void Save(Game game)
    {
        _betRepository.Games.Add(game);
        _betRepository.SaveChanges();
    }
}