using System.Collections.Concurrent;

namespace ClassLib;

public class GameObjects
{
    public Player Player { get; set; }
    
    public BoneFire FlameSpawner { get; set; }
    
    public ConcurrentBag<Flame> FlameEnemies { get; set; }
    
    public ConcurrentBag<СannonBall> BarrelEnemies { get; set; }
    
    public List<Cannon> BarrelSpawners { get; set; }
    
    public CupCake CupCake { get; set; }
    
    public ExpBooster ExpBooster { get; set; }
    
    public HealthBooster HealthBooster { get; set; }
    
    public Key Key { get; set; }
    
    public Dog Dog { get; set; }
}