namespace ClassLib;

public class Door : GameObject
{
    public override bool Transparent { get; set; } = true;
    
    public override char Symbol { get; } = '/';
}