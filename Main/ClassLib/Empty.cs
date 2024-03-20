namespace ClassLib;

public class Empty : GameObject
{
    public override bool Transparent { get; set; } = true;
    
    public override char Symbol { get; } = '.';
    
    public override ConsoleColor Color { get; set; }
}