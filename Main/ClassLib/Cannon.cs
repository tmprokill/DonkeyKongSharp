namespace ClassLib;

public class Cannon : GameObject
{
    public Coordinates Position { get; set; }
    
    public override bool Transparent { get; set; } = false;
    
    public override char Symbol { get; } = 'S';

    public override ConsoleColor Color { get; set; } = ConsoleColor.DarkRed;
}