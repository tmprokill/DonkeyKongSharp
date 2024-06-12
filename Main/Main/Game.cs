using System.Collections.Concurrent;
using ClassLib;
using ClassLib.Enums;
using FileWorkLib;
using OutputLib;

namespace Main;

public class Game
{
    public static void Main()
    {
        //initialization
        bool ini = false;
        var game = GenerateGame();
        
        game.Objects.Player.Name = "login";
        
        var keyReaderThread = new Thread(() => KeyPressHelper.KeyReader(game));
        var flameThread = new Thread(() => Flame.Move(game));
        var flameSpawnerThread = new Thread(() => BoneFire.Spawn(game));
        var barrelSpawnerThread = new Thread(() => Cannon.Spawn(game));
        var barrelThread = new Thread(() => СannonBall.Move(game));
        var dogThread = new Thread(() => Dog.Move(game));
        var gamePrinterThread = new Thread(() => GamePrinter.PrintField(game));
        var nextLevelThread = new Thread(() => LevelInitializeHelper.LevelListener(game));
        var musicPlayerThread = new Thread(() => MusicPlayer.Play(game));

        var threadList = new List<Thread>()
        {
            keyReaderThread, flameThread, 
            flameSpawnerThread, barrelSpawnerThread, 
            barrelThread, gamePrinterThread, 
            nextLevelThread, musicPlayerThread,
            dogThread
        };
        
        while (game.Status != GameStatus.Stopped)
        {
            Console.CursorVisible = false;
            
            Console.WriteLine("Welcome to the DonkeyKong Game!");
            
            Console.WriteLine("Press S to start!");
            
            Console.WriteLine("Press T to get instructions!");
            
            Console.WriteLine("Press I to get your stats!");
            
            Console.WriteLine("Press L to close!");
            
            var key = Console.ReadKey();
            Console.WriteLine();
            
            if (key.Key == ConsoleKey.L) 
            {
                Console.WriteLine(TemplateGetter.GetExit());
                game.Status = GameStatus.Stopped;
                Thread.Sleep(1000);
                Console.Clear();
            }
            else if (key.Key == ConsoleKey.I) 
            {
                Console.WriteLine(TemplateGetter.GetOptions());
                Thread.Sleep(1200);
                Console.Clear();
                StatsSaver.GetResults(game.Objects.Player.Name);
            }
            else if (key.Key == ConsoleKey.T) 
            {
                Console.WriteLine(InstructionsGetter.GetInstructions());
                Console.ReadKey();
                Console.Clear();
            }
            else if (key.Key == ConsoleKey.S)
            {
                Console.WriteLine(TemplateGetter.GetLoading());
                Thread.Sleep(2000);
                Console.Clear();
                
                if (!ini)
                {
                    foreach (var item in threadList)
                    {
                        item.Start();
                    }
                    
                    ini = true;
                }
                
                if (game.Status == GameStatus.Paused)
                {
                    Clear(game);
                }
                
                while (game.Status == GameStatus.Playing)
                {
                    Thread.Sleep(1000);
                }
            }   
        }
    }

    public static GameField GenerateGame()
    {
        var game = new GameField();

        GenerateObjects(game);

        return game;
    }
    
    private static void GenerateObjects(GameField gameField)
    {
        var result = new GameObjects();
        
        var player = new Player();
        
        var boost = new CupCake();

        var exp = new ExpBooster();

        var health = new HealthBooster();

        var key = new Key();

        
        var flameEnemies = new ConcurrentBag<Flame>();
        var barrelEnemies = new ConcurrentBag<СannonBall>();

        var flameSpawner = new BoneFire();
        var barrelSpawnerList = new List<Cannon>();
        
        result.Player = player;
        result.FlameSpawner = flameSpawner;
        result.FlameEnemies = flameEnemies;
        result.BarrelEnemies = barrelEnemies;
        result.BarrelSpawners = barrelSpawnerList;
        result.CupCake = boost;
        result.ExpBooster = exp;
        result.HealthBooster = health;
        result.Key = key;
        
        gameField.Objects = result;

        LevelInitializeHelper.Invoke(25, gameField);
    }

    private static void Clear(GameField gameField)
    {
        Console.Clear();
        gameField.Objects.Player.LevelsPassed = default;
        gameField.Objects.Player.StepsAmount = default;
        gameField.Objects.Player.ItemsCollected = default;
        gameField.Objects.Player.Score = default;
        gameField.Objects.Player.Lives = 3;
        gameField.Status = 0;
        gameField.Difficulty = 0;
        gameField.Objects.BarrelEnemies.Clear();
        
        LevelInitializeHelper.ClearAndGenerate(gameField);
    }
}