namespace UniBet.ValueObjects;

public class Team
{
    public string Value { get; set; } 
    
    public Team()
    {
    }
    public Team(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new Exception("Team nulo!");
        }

        if (value.Length < 3)
        {
            throw new Exception("Team Minimo 3");
        }

        if (value.Length > 20)
        {
            throw new Exception("Team Maximo 20");
        }
        this.Value = value;
    }
}