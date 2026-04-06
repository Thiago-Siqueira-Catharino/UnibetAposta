using UniBet.Contexts.Betting.Domain.ValueObjects;

namespace UniBet.Contexts.Betting.Application.UseCases;

public class CreateBetDTO
{
    public Guid UserId { get; set; }
    public Guid GameId { get; set; }
    public decimal Amount { get; set; }
    public string Team { get; set; }

    public CreateBetDTO(Guid userId, Guid gameId, decimal amount, string team)
    {
        
    }
}