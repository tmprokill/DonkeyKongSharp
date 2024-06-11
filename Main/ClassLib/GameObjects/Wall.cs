namespace ClassLib;

public class Wall : GameObject
{
    public override bool Transparent { get; set; } = false;
    
    public override string Image { get; } = "Wall";

    public override ConsoleColor Color { get; set; } = ConsoleColor.Gray;
}
