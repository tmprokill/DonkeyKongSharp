namespace ClassLib;

public class HealthBooster : GameObject
{
    public Coordinates Position { get; set; }
    
    public override bool Transparent { get; set; } = true;
    
    public override char Symbol { get; } = 'H';
    
    public override ConsoleColor Color { get; set; } = ConsoleColor.Red;
}