namespace ClassLib;

public class Key : GameObject
{
    public Coordinates Position { get; set; }

    public Coordinates Opens { get; set; }
    
    public override bool Transparent { get; set; } = true;
    
    public override char Symbol { get; } = 'K';
    
    public override ConsoleColor Color { get; set; } = ConsoleColor.White;
}