namespace UniBet.Contexts.Betting.Application.UseCases.GetBet;

public class GetBetRequest
{
    public Guid Id { get; set; }

    public GetBetRequest(Guid id)
    {
        Id = id;
    }
}