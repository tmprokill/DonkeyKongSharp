using System.Collections.Concurrent;

namespace ClassLib;

public class ObjectCollection
{
    public Game Game { get; set; }
    
    public Player Player { get; set; }
    
    public BoneFire FlameSpawner { get; set; }
    
    public ConcurrentBag<Flame> FlameEnemies { get; set; }
    
    public ConcurrentBag<Сannonball> BarrelEnemies { get; set; }
    
    public List<Cannon> BarrelSpawners { get; set; }
    
    public CupCake Boost { get; set; }
    
    public ExpBooster Exp { get; set; }
    
    public HealthBooster Health { get; set; }
    
    public Key Key { get; set; }
}