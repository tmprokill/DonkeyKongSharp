namespace ClassLib;

public class Enemy
{
    public string Direction { get; set; }
    
    public int Level { get; set; }
    
    public int HealPoints { get; set; }
    
    public Coordinates Position { get; set; }

    public char Symbol { get; } = 'E';
}