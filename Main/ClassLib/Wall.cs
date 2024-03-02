namespace ClassLib;

public class Wall : GameObject
{
    public override bool Transparent { get; set; } = false;
    public override char Symbol { get; } = '#';
}
