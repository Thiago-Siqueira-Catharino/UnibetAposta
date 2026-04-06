using UniBet.Contexts.Betting.Domain.Entities;
using UniBet.Contexts.Betting.Domain.IRepositories;

namespace UniBet.Contexts.Betting.Application.UseCases.GetBet;

public class GetBetUseCase
{
    private readonly IBetRepository _betRepository;
    
    public GetBetUseCase(IBetRepository betRepository)
    {
        _betRepository = betRepository;
    }

    public GetBetResponse Run(GetBetRequest getBetRequest)
    {
        Bet bet = _betRepository.findById(getBetRequest.Id);
        if (bet == null)
            throw new ArgumentException("Bet not found");
        
        return new GetBetResponse(bet.UserId, bet.GameId, bet.Amount.Value, bet.Team);
        
    }
}