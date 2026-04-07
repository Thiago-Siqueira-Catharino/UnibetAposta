namespace UniBet.Contexts.Betting.Domain.ValueObjects;

public class Team
{
    public string Value { get; }

    public Team()
    {
    }

    public Team(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new Exception("Team inválido");

        if (value.Length < 3)
            throw new Exception("Team mínimo 3 caracteres");

        if (value.Length > 20)
            throw new Exception("Team máximo 20 caracteres");

        Value = value;
    }

    
    public override bool Equals(object obj)
    {
        if (obj is not Team other)
            return false;

        return Value.Equals(other.Value, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode()
    {
        return Value.ToLower().GetHashCode();
    }

    public override string ToString()
    {
        return Value;
    }
}
