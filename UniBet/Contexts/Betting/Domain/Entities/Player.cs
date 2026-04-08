using UniBet.Contexts.Betting.Domain.ValueObjects;

namespace UniBet.Contexts.Betting.Domain.Entities
{
    public class Player : EntitiyBase
    {
        public string Document {  get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Amount Amount { get; set; }
        private List<Bet> _bets;
        public IReadOnlyList<Bet> Bets => _bets;

        public void Debit(Amount amount)
        {
            if (this.Amount.Value < amount.Value)
            {
                throw new Exception("Saldo Insuficiente");
            }

            this.Amount.Value -= amount.Value;
        }
        
        public void Deposit(Amount amount)
        {
            this.Amount.Value += amount.Value;
        }
    }
}
