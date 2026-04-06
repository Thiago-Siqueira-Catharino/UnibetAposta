using UniBet.Contexts.Betting.Domain.IRepositories;
using UniBet.Contexts.Betting.Domain.Entities;
using UniBet.Contexts.Betting.Domain.ValueObjects;

namespace UniBet.Contexts.Betting.Application.UseCases.CreateBet;

public class CreateBetUseCase
{
    private readonly IPlayerRepository _userRepository;
    private readonly IGameRepository _gameRepository;
    
    public CreateBetUseCase(IPlayerRepository playerRepository, IGameRepository gameRepository)
    {
        _userRepository = playerRepository;
        _gameRepository = gameRepository;   
    }

    public void Run(CreateBetDTO request)
    {
        try
        {
            Player player = _userRepository.FindById(request.UserId);
            if (player == null) 
            {
                throw new Exception("User Invalido");
            }

            Game game = _gameRepository.FindById(request.GameId);
            if (game == null) 
            {
                throw new Exception("Jogo Invalido");
            }

            player.Debit(new Amount(request.Amount));
            game.Place(request.UserId, new Amount(request.Amount), new Team(request.Team));

            _userRepository.Update(player);
            _gameRepository.Update(game);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);    
        }
    }
}