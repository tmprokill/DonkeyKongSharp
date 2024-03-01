namespace ClassLib;

public class Player : GameObject
{
    public Coordinates Position { get; set; }
    public override char Symbol { get;} = 'P';
}