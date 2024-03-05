namespace ClassLib;

public class KeyPressHandler
{
    public void HandleKeyPress(ConsoleKey key, Player player, Game gameBoard)
    {
        switch (key)
        {
            case ConsoleKey.UpArrow:
                Player.MovePlayer(new Coordinates(){X = -1, Y = 0}, player, gameBoard);
                break;
            case ConsoleKey.DownArrow:
                Player.MovePlayer(new Coordinates(){X = 1, Y = 0}, player, gameBoard);
                break;
            case ConsoleKey.RightArrow:
                Player.MovePlayer(new Coordinates(){X = 0, Y = 1}, player, gameBoard);
                break;
            case ConsoleKey.LeftArrow:
                Player.MovePlayer(new Coordinates(){X = 0, Y = -1}, player, gameBoard);
                break;
        }
    }
}