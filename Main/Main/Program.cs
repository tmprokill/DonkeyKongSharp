using System.Collections.Concurrent;
using ClassLib;
using ThreadLib;

namespace Main;

internal class Program
{
    internal static void Main(string[] args)
    {
        //initialization
        var collection = GenerateObjectCollection();
            
        var keyReaderThread = new Thread(() => ThreadSpawner.KeyReader(collection.Game, collection.Player));
        var flameThread = new Thread(() => ThreadSpawner.Flame(collection.Game, collection.FlameEnemies, collection.Player));
        var flameSpawnerThread = new Thread(() => ThreadSpawner.FlameSpawner(collection.Game, collection.FlameEnemies, collection.FlameSpawner));
        var barrelSpawnerThread = new Thread(() => ThreadSpawner.BarrelSpawner(collection.Game, collection.BarrelEnemies, collection.BarrelSpawners));
        var barrelThread = new Thread(() => ThreadSpawner.Barrel(collection.Game, collection.BarrelEnemies, collection.Player));
        var gamePrinterThread = new Thread(() => ThreadSpawner.PrintField(collection.Game, collection.Player));
        var nextLevel = new Thread(() => ThreadSpawner.LevelListener(collection));
        var musicPlayer = new Thread(() => ThreadSpawner.MusicPlayer(collection.Game));
        
        gamePrinterThread.Start();
        keyReaderThread.Start();
        flameSpawnerThread.Start();
        barrelSpawnerThread.Start();
        flameThread.Start();
        barrelThread.Start();
        nextLevel.Start();
        musicPlayer.Start();
    }

    internal static ObjectCollection GenerateObjectCollection()
    {
        var result = new ObjectCollection();
        var game = new Game();
        
        var player = new Player();
        
        var boost = new CupCake();

        var exp = new ExpBooster();
        
        var flameEnemies = new ConcurrentBag<EnemyFlame>();
        var barrelEnemies = new ConcurrentBag<EnemyBarrel>();

        var flameSpawner = new EnemyFlameSpawner();
        var barrelSpawnerList = new List<EnemyBarrelSpawner>();
        
        
        LevelInitializer.GenerateMatrixTemplate(25, game);
        LevelInitializer.InitializeLevel(game, player, flameSpawner, barrelSpawnerList, boost, exp);

        result.Game = game;
        result.Player = player;
        result.FlameSpawner = flameSpawner;
        result.FlameEnemies = flameEnemies;
        result.BarrelEnemies = barrelEnemies;
        result.BarrelSpawners = barrelSpawnerList;
        result.Boost = boost;
        result.Exp = exp;
        
        return result;
    }
}