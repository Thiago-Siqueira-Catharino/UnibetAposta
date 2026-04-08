using UniBet.Contexts.Betting.Domain.IRepositories;
using UniBet.Contexts.Betting.Domain.Entities;
using UniBet.Contexts.Betting.Domain.ValueObjects;

namespace UniBet.Contexts.Betting.Application.UseCases.CancelBet;

public class CancelBetUseCase
{
    private readonly IBetRepository _betRepository;
    private readonly IPlayerRepository _userRepository;
    private readonly IGameRepository _gameRepository;

    public CancelBetUseCase(IPlayerRepository playerRepository, IGameRepository gameRepository, IBetRepository betRepository)
    {
        _betRepository = betRepository;
        _userRepository = playerRepository;
        _gameRepository = gameRepository;
    }

    public void Run(Guid betId)
    {
        try
        {
            Bet betToCancel = _betRepository.findById(betId);
            if (betToCancel == null)
                throw new ArgumentException("Invalid betId");
            
            Player player = _userRepository.FindById(betToCancel.UserId);
            if (player == null)
                throw new ArgumentException("Invalid playerId");
            
            if (betToCancel.GameId == Guid.Empty)
                throw new ArgumentException("Invalid gameId");
            
            Console.WriteLine(betToCancel.GameId);
            Guid gameId = betToCancel.GameId;
            Console.WriteLine(gameId);
            Game game = _gameRepository.FindById(gameId);
            if (game == null)
                throw new ArgumentException("Invalid gameId");
            
            player.Deposit(betToCancel.Amount);
            _userRepository.Update(player);
            
            betToCancel.Close();
            _betRepository.Save(betToCancel);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}