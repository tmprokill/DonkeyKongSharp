using System.Collections.Concurrent;
using System.Reflection;
using ClassLib;
using FileWorkLib;
using ThreadLib;

namespace Main;

internal class Program
{
    internal static void Main(string[] args)
    {
        //initialization
        bool ini = false;
        var collection = GenerateObjectCollection();
        
        Console.WriteLine("Enter your name!");
        collection.Player.Name = Console.ReadLine() ?? "default";
        
        var keyReaderThread = new Thread(() => ThreadSpawner.KeyReader(collection.Game, collection.Player));
        var flameThread = new Thread(() => ThreadSpawner.Flame(collection.Game, collection.FlameEnemies, collection.Player));
        var flameSpawnerThread = new Thread(() => ThreadSpawner.FlameSpawner(collection.Game, collection.FlameEnemies, collection.FlameSpawner));
        var barrelSpawnerThread = new Thread(() => ThreadSpawner.CannonSpawner(collection.Game, collection.BarrelEnemies, collection.BarrelSpawners));
        var barrelThread = new Thread(() => ThreadSpawner.CannonBall(collection.Game, collection.BarrelEnemies, collection.Player));
        var gamePrinterThread = new Thread(() => ThreadSpawner.PrintField(collection.Game, collection.Player));
        var nextLevelThread = new Thread(() => ThreadSpawner.LevelListener(collection));
        var musicPlayerThread = new Thread(() => ThreadSpawner.MusicPlayer(collection.Game));

        var threadList = new List<Thread>()
        {
            keyReaderThread, flameThread, 
            flameSpawnerThread, barrelSpawnerThread, 
            barrelThread,gamePrinterThread, 
            nextLevelThread, musicPlayerThread
        };
        
        while (true)
        {
            
            Console.CursorVisible = false;
            
            Console.WriteLine("Welcome to the DonkeyKong Game!");
            
            
            Console.WriteLine("Press S to start!");
            
            Console.WriteLine("Press I to get your stats!");
            
            Console.WriteLine("Press L to close!");
            
            var key = Console.ReadKey();
            Console.WriteLine();
            
            if (key.Key == ConsoleKey.L) 
            {
                foreach (var item in threadList)
                {
                    item.Interrupt();
                }
                
                break;
            }
            
            if (key.Key == ConsoleKey.I) 
            {
                StatsSaver.GetResults(collection.Player.Name);
            }
            
            if (key.Key == ConsoleKey.S)
            {
                if (!ini)
                {
                    foreach (var item in threadList)
                    {
                        item.Start();
                    }
                    
                    ini = true;
                }
                
                if (collection.Game.Status != 0)
                {
                    Clear(collection);
                }
                
                while (collection.Game.Status == 0)
                {
                    Thread.Sleep(1000);
                }
            }
        }
        
    }

    internal static ObjectCollection GenerateObjectCollection()
    {
        var result = new ObjectCollection();
        var game = new Game();
        
        var player = new Player();
        
        var boost = new CupCake();

        var exp = new ExpBooster();

        var health = new HealthBooster();
        
        var flameEnemies = new ConcurrentBag<Flame>();
        var barrelEnemies = new ConcurrentBag<Сannonball>();

        var flameSpawner = new BoneFire();
        var barrelSpawnerList = new List<Cannon>();
        
        
        LevelInitializer.GenerateMatrixTemplate(25, game);
        LevelInitializer.InitializeLevel(game, player, flameSpawner, barrelSpawnerList, boost, exp, health);

        result.Game = game;
        result.Player = player;
        result.FlameSpawner = flameSpawner;
        result.FlameEnemies = flameEnemies;
        result.BarrelEnemies = barrelEnemies;
        result.BarrelSpawners = barrelSpawnerList;
        result.Boost = boost;
        result.Exp = exp;
        result.Health = health;
        
        return result;
    }

    private static void Clear(ObjectCollection collection)
    {
        Console.Clear();
        
        collection.Game.Status = 0;
        collection.Game.Difficulty = 0;
        collection.Game.Score = 0;
        collection.Player.Lives = 3;
        collection.BarrelEnemies.Clear();
        
        LevelInitializer.ClearAndGenerate(collection);
    }
}