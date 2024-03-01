namespace ClassLib;

public class Wall : GameObject
{
    public bool Transparent { get; set; }
    public override char Symbol { get;  } = '#';
}