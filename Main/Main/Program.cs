using ClassLib;

namespace Main;

internal class Program
{
    
    internal static void Main(string[] args)
    {
        //initialization
        var game = new Game();
        var player = new Player() { Position = new Coordinates() { X = 23, Y = 1 } };
        var gameFieldHelper = new FieldHelper();
        
        var flameEnemies = new List<EnemyFlame>();
        var barrelEnemies = new List<EnemyBarrel>();

        var flameSpawn = LevelInitializer.SetFlameSpawn();
        var barrelSpawn = LevelInitializer.SetBarrelSpawn();
        
        LevelInitializer.GenerateMatrixTemplate(25, game);
        LevelInitializer.InitializeLevel(game);
        
        var keyReaderThread = new Thread(() => KeyReader(game, player));
        var flameThread = new Thread(() => Flame(game, flameEnemies));
        var flameSpawnerThread = new Thread(() => FlameSpawner(game, flameEnemies, flameSpawn));
        var barrelSpawnerThread = new Thread(() => BarrelSpawner(game, barrelEnemies, barrelSpawn));
        var barrelThread = new Thread(() => Barrel(game, barrelEnemies));
        var gamePrinterThread = new Thread(() => PrintField(game));
        
        

        gamePrinterThread.Start();
        keyReaderThread.Start();
        flameSpawnerThread.Start();
        barrelSpawnerThread.Start();
        flameThread.Start();
        barrelThread.Start();
    }

    private static void FlameSpawner(Game game, List<EnemyFlame> list ,Coordinates spawn)
    {
        while (game.Status == 0)
        {
            list.Add(new EnemyFlame() { Position = new Coordinates(spawn) });
            Thread.Sleep(10000);
        }
    }

    private static void BarrelSpawner(Game game, List<EnemyBarrel> list, Coordinates spawn)
    {
        while (game.Status == 0)
        {
            list.Add(new EnemyBarrel { Position = new Coordinates(spawn) });
            Thread.Sleep(10000);
        }
    }
    
    private static void Flame(Game game, List<EnemyFlame> flames)
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

    private static void Barrel(Game game, List<EnemyBarrel> barrels)
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
    private static void PrintField(Game game)
    {
        var gameExecutor = new GameExecutor();
        
        while (game.Status == 0)
        {
            gameExecutor.PrintMatrix(game.FieldMatrix);
            Thread.Sleep(1000/144);
        }
        
        GameFinisher(game);
    }
    
    private static void KeyReader(Game game, Player player)
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