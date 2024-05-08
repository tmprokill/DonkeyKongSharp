using ClassLib.Enums;

namespace ClassLib;

public class KeyPressHelper
{
    public static void KeyReader(GameField gameField)
    {
        var player = gameField.Objects.Player;
        var keyHandler = new KeyPressHelper();
        
        while (gameField.Status != GameStatus.Stopped)
        {
            while (gameField.Status == GameStatus.Playing)
            {
                var keyInfo = Console.ReadKey();
                player.StepsAmount += 1;
                keyHandler.HandleKeyPress(keyInfo.Key, gameField);
            }
            
            while (gameField.Status == GameStatus.Paused)
            {
                Thread.Sleep(1000);
            }
        }
    }
    
    private void HandleKeyPress(ConsoleKey key, GameField gameField)
    {
        switch (key)
        {
            case ConsoleKey.UpArrow:
                Player.MovePlayer(new Coordinates(){X = -1, Y = 0}, gameField.Objects.Player, gameField);
                break;
            case ConsoleKey.DownArrow:
                Player.MovePlayer(new Coordinates(){X = 1, Y = 0}, gameField.Objects.Player, gameField);
                break;
            case ConsoleKey.RightArrow:
                Player.MovePlayer(new Coordinates(){X = 0, Y = 1}, gameField.Objects.Player, gameField);
                break;
            case ConsoleKey.LeftArrow:
                Player.MovePlayer(new Coordinates(){X = 0, Y = -1}, gameField.Objects.Player, gameField);
                break;
            case ConsoleKey.H:
                gameField.Status = GameStatus.Paused;
                break;
        }
    }
}