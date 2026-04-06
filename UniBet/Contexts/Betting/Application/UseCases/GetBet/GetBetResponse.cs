using UniBet.Contexts.Betting.Domain.ValueObjects;

namespace UniBet.Contexts.Betting.Application.UseCases.GetBet;

public class GetBetResponse
{
    public Guid UserId { get; set; }
    public Guid GameId { get; set; }
    public decimal Amount { get; set; }
    public Team Team { get; set; }

    public GetBetResponse(Guid userId, Guid gameId, decimal amount, Team team)
    {
        UserId = userId;
        GameId = gameId;
        Amount = amount;
        Team = team;
    }
}