namespace ClassLib;

public class EnemyFlameSpawner : GameObject
{
    public Coordinates Position { get; set; }
    
    public override bool Transparent { get; set; } = false;
    
    public override char Symbol { get; } = 'S';
}