namespace ClassLib;

public class Empty : GameObject
{
    public override bool Transparent { get; set; } = true;

    public override char Symbol { get; set; } = '.';
    
    public override string Image { get; } = "BackGround";

    public override ConsoleColor Color { get; set; } = ConsoleColor.Gray;
}