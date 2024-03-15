using System.Collections.Concurrent;
using ClassLib;
using ThreadLib;

namespace Main;

internal class Program
{
    
    internal static void Main(string[] args)
    {
        //initialization
        var game = new Game();
        var player = new Player() { Position = new Coordinates() { X = 23, Y = 1 } };
        
        var flameEnemies = new ConcurrentBag<EnemyFlame>();
        var barrelEnemies = new ConcurrentBag<EnemyBarrel>();

        var flameSpawner = new EnemyFlameSpawner();
        var barrelSpawnerList = new List<EnemyBarrelSpawner>();
        
        flameSpawner.Position = LevelInitializer.SetFlameSpawn();
        
        LevelInitializer.GenerateMatrixTemplate(25, game);
        LevelInitializer.InitializeLevel(game, player, flameSpawner, barrelSpawnerList);
        
        var keyReaderThread = new Thread(() => ThreadSpawner.KeyReader(game, player));
        var flameThread = new Thread(() => ThreadSpawner.Flame(game, flameEnemies));
        var flameSpawnerThread = new Thread(() => ThreadSpawner.FlameSpawner(game, flameEnemies, flameSpawner.Position));
        var barrelSpawnerThread = new Thread(() => ThreadSpawner.BarrelSpawner(game, barrelEnemies, barrelSpawnerList));
        var barrelThread = new Thread(() => ThreadSpawner.Barrel(game, barrelEnemies));
        var gamePrinterThread = new Thread(() => ThreadSpawner.PrintField(game));
        
        
        gamePrinterThread.Start();
        keyReaderThread.Start();
        flameSpawnerThread.Start();
        barrelSpawnerThread.Start();
        flameThread.Start();
        barrelThread.Start();
    }
}