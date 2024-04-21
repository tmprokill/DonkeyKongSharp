namespace ClassLib;

public class BoneFire : GameObject
{
    public Coordinates Position { get; set; }
    
    public override bool Transparent { get; set; } = false;
    
    public override char Symbol { get; } = 'B';

    public override ConsoleColor Color { get; set; } = ConsoleColor.DarkRed;
}