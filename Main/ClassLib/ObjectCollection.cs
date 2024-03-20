using System.Collections.Concurrent;

namespace ClassLib;

public class ObjectCollection
{
    public Game Game { get; set; }
    
    public Player Player { get; set; }
    
    public EnemyFlameSpawner FlameSpawner { get; set; }
    
    public ConcurrentBag<EnemyFlame> FlameEnemies { get; set; }
    
    public ConcurrentBag<EnemyBarrel> BarrelEnemies { get; set; }
    
    public List<EnemyBarrelSpawner> BarrelSpawners { get; set; }
    
    public CupCake Boost { get; set; }
    
    public ExpBooster Exp { get; set; }
}