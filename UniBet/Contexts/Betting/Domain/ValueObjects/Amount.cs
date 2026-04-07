namespace UniBet.Contexts.Betting.Domain.ValueObjects
{
    public class Amount
    {
        public decimal Value { get; }

        public Amount(decimal value)
        {
            if (value <= 0)
                throw new Exception("Valor deve ser maior que zero");

            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj is not Amount other)
                return false;

            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.ToString("F2");
        }
    }
}
