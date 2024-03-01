namespace ClassLib;

public class MovementHelper
{
    public void HandleKeyPress(ConsoleKey key, Player player, GameObject[][] gameBoard)
    {
        switch (key)
        {
            case ConsoleKey.UpArrow:
                MovePlayer(new Coordinates(){X = -1, Y = 0}, player, gameBoard);
                break;
            case ConsoleKey.DownArrow:
                MovePlayer(new Coordinates(){X = 1, Y = 0}, player, gameBoard);
                break;
            case ConsoleKey.RightArrow:
                MovePlayer(new Coordinates(){X = 0, Y = 1}, player, gameBoard);
                break;
            case ConsoleKey.LeftArrow:
                MovePlayer(new Coordinates(){X = 0, Y = -1}, player, gameBoard);
                break;
        }
    }

    private void MovePlayer(Coordinates cord, Player player, GameObject[][] gameBoard)
    {
        
        int tempX = cord.X + player.Position.X;
        int tempY = cord.Y + player.Position.Y;

        if (tempX >= 0 && tempX < gameBoard.Length && tempY >= 0 && tempY < gameBoard[0].Length)
        {
            gameBoard[player.Position.X][player.Position.Y] = new EmptyCell();//неправильно
            player.Position.X = tempX;
            player.Position.Y = tempY;
        }
    }
}