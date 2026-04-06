using UniBet.Contexts.Betting.Domain.ValueObjects;

namespace UniBet.Contexts.Betting.Domain.Entities
{
    public class Bet : EntitiyBase
    {
        public Player player { get; private set; }
        public Game Game { get; private set; }
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }
        public bool Active { get; private set; }
        public Amount Amount { get; set; }
        public Team Team { get; set; }

        private Bet() { }
        public Bet(Guid gameId, Guid userId, Amount amount, Team team) 
        {
            this.UserId = userId;
            this.Amount = amount;
            this.Team = team;
            this.GameId = gameId;
            this.Active = true;
        }

        public void setPlayer(Player player)
        {
            this.player = player;
        }

        public void setGame(Game game)
        {
            this.Game = game;
        }
        
        public void Close()
        {
            Active = false;
        }
    }
}
