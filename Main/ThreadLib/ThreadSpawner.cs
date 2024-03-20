using System.Collections.Concurrent;
using OutputLib;
using ClassLib;
using FileWorkLib;

namespace ThreadLib;

public class ThreadSpawner
{
    public static Dictionary<int, Dictionary<string, double>> DifficultyCoefficients = new Dictionary<int, Dictionary<string, double>>
    {
        {
            0, new Dictionary<string, double>
            {
                { "spawn", 0.5 }, 
                { "movement", 1.0 } 
            }
        },
        {
            1, new Dictionary<string, double>
            {
                { "spawn", 1.0 }, 
                { "movement", 1.0 } 
            }
        },
        {
            2, new Dictionary<string, double>
            {
                { "spawn", 1.5 },
                { "movement", 1.5 } 
            }
        }
    };
    
    public static void FlameSpawner(Game game, ConcurrentBag<EnemyFlame> list , EnemyFlameSpawner flame)
    {
        while (game.Status == 0)
        {   
            if (game.BarrelRunning == false)
            {
                Thread.Sleep(5000);
                game.BarrelRunning = true;
            }
            
            list.Add(new EnemyFlame() { Position = new Coordinates(flame.Position) });
            Thread.Sleep( (int)(6000 / DifficultyCoefficients[game.Difficulty]["spawn"]));
        }
    }

    public static void BarrelSpawner(Game game, ConcurrentBag<EnemyBarrel> list, List<EnemyBarrelSpawner> spawners)
    {
        while (game.Status == 0)
        {
            if (game.BarrelRunning == false)
            {
                Thread.Sleep(5000);
                game.BarrelRunning = true;
            }
            
            foreach (var item in spawners)
            {
                list.Add(new EnemyBarrel { Position = new Coordinates(item.Position), Direction = item.Position.Y < 13 ? 1 : -1});
            }
            Thread.Sleep((int) (5000 / DifficultyCoefficients[game.Difficulty]["spawn"]));
        }
    }
    
    public static void Flame(Game game, ConcurrentBag<EnemyFlame> flames,  Player player)
    {
        while (game.Status == 0)
        {
            if (game.FlameRunning == false)
            {
                Thread.Sleep(5000);
                game.FlameRunning = true;
            }
            
            foreach (var flame in flames)
            {
                flame.MoveFlame(game, player);
            }
            
            Thread.Sleep((int) (1000 / DifficultyCoefficients[game.Difficulty]["movement"]));
        }
    }

    public static void Barrel(Game game, ConcurrentBag<EnemyBarrel> barrels, Player player)
    {
        while (game.Status == 0)
        {
            if (game.BarrelRunning == false)
            {
                Thread.Sleep(5000);
                game.BarrelRunning = true;
            }
            
            foreach (var barrel in barrels)
            { 
                barrel.MoveBarrel(game, player);
            }
            
            Thread.Sleep((int)(800 / DifficultyCoefficients[game.Difficulty]["movement"]));
        }
    }
    
    public static void PrintField(Game game, Player player)
    {
        var gameEx = new GameExecutor();
        while (game.Status == 0)
        {
            gameEx.PrintMatrix(game, player);
            Thread.Sleep(1000/144);
        }
        
        GameFinisher(game);
    }
    
    public static void KeyReader(Game game, Player player)
    {
        var keyHandler = new KeyPressHandler();
        
        while (game.Status == 0)
        {
            var keyInfo = Console.ReadKey();
            keyHandler.HandleKeyPress(keyInfo.Key, player, game);
        }
    }

    public static void MusicPlayer(Game game)
    {
        var music = new MusicPlayer();
        music.PlayMusic(game);
    }
    
    public static void LevelListener(ObjectCollection collection)
    {
        while (collection.Game.Status == 0)
        {
            if (collection.Player.Position.X == 0)
            {
                collection.Game.Difficulty = collection.Game.Difficulty < 2
                    ? collection.Game.Difficulty + 1
                    : collection.Game.Difficulty;
                collection.Game.Score += 10000;
                LevelInitializer.ClearAndGenerate(collection);
            }
        }
    }
    
    private static void GameFinisher(Game game)
    {
        var highScore = ResultKeeper.GetScore();
        if (game.Status == -1)
        {
            if (game.Score > highScore)
            {
                ResultKeeper.WriteScore(game.Score);
                Console.WriteLine("You've beaten the record!");
            }
            
            Console.WriteLine($"GameScore: {game.Score}");
        }
        
    }
}