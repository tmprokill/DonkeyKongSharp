namespace ClassLib;

public class CupCake : GameObject
{
    public Coordinates Position { get; set; }
    
    public override bool Transparent { get; set; } = true;
    
    public override char Symbol { get; } = 'C';

    public override ConsoleColor Color { get; set; } = ConsoleColor.Magenta;
}