namespace ClassLib;

public class ExpBooster : GameObject
{
    public Coordinates Position { get; set; }
    
    public override bool Transparent { get; set; } = true;
    
    public override char Symbol { get; } = 'E';

    public override ConsoleColor Color { get; set; } = ConsoleColor.Yellow;
}