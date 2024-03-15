using System.Collections.Concurrent;
using OutputLib;
using ClassLib;

namespace ThreadLib;

public class ThreadSpawner
{
    public static void FlameSpawner(Game game, ConcurrentBag<EnemyFlame> list ,Coordinates spawn)
    {
        while (game.Status == 0)
        {
            list.Add(new EnemyFlame() { Position = new Coordinates(spawn) });
            Thread.Sleep(1000);
        }
    }

    public static void BarrelSpawner(Game game, ConcurrentBag<EnemyBarrel> list, List<EnemyBarrelSpawner> spawners)
    {
        while (game.Status == 0)
        {
            foreach (var item in spawners)
            {
                list.Add(new EnemyBarrel { Position = new Coordinates(item.Position), Direction = item.Position.Y < 13 ? 1 : -1});
            }
            Thread.Sleep(10000);
        }
    }
    
    public static void Flame(Game game, ConcurrentBag<EnemyFlame> flames)
    {
        while (game.Status == 0)
        {
            foreach (var flame in flames)
            {
                flame.MoveFlame(game);
            }
            
            Thread.Sleep(1000);
        }
    }

    public static void Barrel(Game game, ConcurrentBag<EnemyBarrel> barrels)
    {
        while (game.Status == 0)
        {
            foreach (var barrel in barrels)
            { 
                barrel.MoveBarrel(game);
            }
            
            Thread.Sleep(800);
        }
    }
    public static void PrintField(Game game)
    {
        var gameExecutor = new GameExecutor();
        
        while (game.Status == 0)
        {
            gameExecutor.PrintMatrix(game.FieldMatrix);
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
    
    private static void GameFinisher(Game game)
    {
        if (game.Status == -1)
        {
            Console.WriteLine("You've lost");
        }
        else if (game.Status == 1)
        {
            Console.WriteLine("You've won");
        }
    }
}