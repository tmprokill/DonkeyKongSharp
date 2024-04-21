namespace ClassLib;

public class Door : GameObject
{
    public override bool Transparent { get; set; } = true;
    
    public override char Symbol => Transparent == false ? '@' : '/';

    public override ConsoleColor Color { get; set; } = ConsoleColor.DarkBlue;
}