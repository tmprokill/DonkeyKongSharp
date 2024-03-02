namespace ClassLib;

public class MovementHelper
{
    public void HandleKeyPress(ConsoleKey key, Player player, Cell[][] gameBoard)
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

    private void MovePlayer(Coordinates cord, Player player, Cell[][] gameBoard)
    {
        int tempX = cord.X + player.Position.X;
        int tempY = cord.Y + player.Position.Y;

        if (CheckAccessibility((tempX,tempY), gameBoard) && CheckTransparity((tempX, tempY), gameBoard))
        {
            gameBoard[player.Position.X][player.Position.Y].Current = null;
            player.Position.X = tempX;
            player.Position.Y = tempY;
        }
    }

    private bool CheckAccessibility((int, int) values, Cell[][] gameBoard)
    {
        if (values.Item1 >= 0 && values.Item1 < gameBoard.Length && values.Item2 >= 0 && values.Item2 < gameBoard[0].Length)
        {
            return true;
        }

        return false;
    }
    private bool CheckTransparity((int,int) values, Cell[][] gameboard)
    {
        if (gameboard[values.Item1][values.Item2].Init.Transparent != true)
        {
            return false;
        }

        return true;
    }
}