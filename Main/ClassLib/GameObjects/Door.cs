namespace ClassLib;

public class Door : GameObject
{
    public override bool Transparent { get; set; } = true;

    public override char Symbol { get; set; } = '/';
    
    public override string Image => Transparent == false ? "Door_Closed" : "Door_Opened";

    public override ConsoleColor Color { get; set; } = ConsoleColor.DarkBlue;
}