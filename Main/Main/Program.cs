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
        var gameField = new Game();
        var flame = new EnemyFlame();

        gameField.GenerateMatrixTemplate(25);
        gameFieldHelper.InitializeGameField(gameField.FieldMatrix);
        
        Thread keyReaderThread = new Thread(() => KeyReader(gameField, player));
        Thread flameThread = new Thread(() => Flame(gameField, flame));
        Thread gamePrinterThread = new Thread(() => PrintField(gameField));
        
        

        gamePrinterThread.Start();
        keyReaderThread.Start();
        flameThread.Start();
    }

    private static void Flame(Game game, EnemyFlame flame)
    {
        while (game.Status == 0)
        {
            flame.MoveFlame(game);
            Thread.Sleep(1000);
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