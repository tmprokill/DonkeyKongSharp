namespace ClassLib;

public class EnemyBarrelSpawner : GameObject
{
    public Coordinates Position { get; set; }
    
    public override bool Transparent { get; set; } = false;
    
    public override char Symbol { get; } = 'S';
}